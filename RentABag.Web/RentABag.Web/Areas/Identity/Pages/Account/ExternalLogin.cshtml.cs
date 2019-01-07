using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RentABag.Models;
using RentABag.Services.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RentABag.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ExternalLoginModel : PageModel
    {
        private const string LocationClaimsType = "urn:facebook:location";
        private readonly SignInManager<RentABagUser> _signInManager;
        private readonly UserManager<RentABagUser> _userManager;
        private readonly ILogger<ExternalLoginModel> _logger;

        public ExternalLoginModel(
            SignInManager<RentABagUser> signInManager,
            UserManager<RentABagUser> userManager,
            ILogger<ExternalLoginModel> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string LoginProvider { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [Display(Name = "Username")]
            public string UserName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [Display(Name = "FullName")]
            public string FullName { get; set; }

            [Required]
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [Display(Name = "Country")]
            public string Country { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [Display(Name = "City")]
            public string City { get; set; }

            [Required]
            [StringLength(10, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [Display(Name = "PostCode")]
            public string PostCode { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [Display(Name = "Address")]
            public string ActualAddress { get; set; }

            [Required]
            [Birthdate(ErrorMessage = "Required minimum age: {0}")]
            [DataType(DataType.Date)]
            [Display(Name = "Birthday")]
            public DateTime Birthday { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
        }

        public IActionResult OnGetAsync()
        {
            return RedirectToPage("./Login");
        }

        public IActionResult OnPost(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Page("./ExternalLogin", pageHandler: "Callback", values: new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> OnGetCallbackAsync(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (remoteError != null)
            {
                ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Error loading external login information.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            // Sign in the user with this external login provider if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                _logger.LogInformation("{Name} logged in with {LoginProvider} provider.", info.Principal.Identity.Name, info.LoginProvider);
                return LocalRedirect(returnUrl);
            }
            if (result.IsLockedOut)
            {
                return RedirectToPage("./Lockout");
            }
            else
            {
                // If the user does not have an account, then ask the user to create an account.
                ReturnUrl = returnUrl;
                LoginProvider = info.LoginProvider;
                if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Email))
                {
                    var city = info.Principal.FindFirstValue(LocationClaimsType).Split(", ").First();
                    var country = info.Principal.FindFirstValue(LocationClaimsType).Split(", ").Last();
                    var bday = info.Principal.FindFirstValue(ClaimTypes.DateOfBirth);
                    Input = new InputModel
                    {
                        Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                        Birthday = bday == null ? DateTime.Now : DateTime.ParseExact(bday, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                        Country = country,
                        City = city,
                        FullName = info.Principal.FindFirstValue(ClaimTypes.Name),
                        PhoneNumber = info.Principal.FindFirstValue(ClaimTypes.MobilePhone),
                        UserName = info.Principal.FindFirstValue(ClaimTypes.Name),
                    };
                }
                return Page();
            }
        }

        public async Task<IActionResult> OnPostConfirmationAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            // Get the information about the user from the external login provider
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Error loading external login information during confirmation.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            if (ModelState.IsValid)
            {
                var address = new Address
                {
                    PostCode = Input.PostCode,
                    ActualAddress = Input.ActualAddress,
                    City = Input.City,
                    Country = Input.Country
                };
                var user = new RentABagUser { UserName = Input.UserName, Email = Input.Email, FullName = Input.FullName, Address = address, Birthday = Input.Birthday, PhoneNumber = Input.PhoneNumber };
                var result1 = await _userManager.CreateAsync(user);
                var result2 = await _userManager.AddToRoleAsync(user, "User");
                if (result1.Succeeded && result2.Succeeded)
                {
                    result1 = await _userManager.AddLoginAsync(user, info);
                    if (result1.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        _logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result1.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                foreach (var error in result2.Errors.Where(e => !result1.Errors.Contains(e)))
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            LoginProvider = info.LoginProvider;
            ReturnUrl = returnUrl;
            return Page();
        }
    }
}
