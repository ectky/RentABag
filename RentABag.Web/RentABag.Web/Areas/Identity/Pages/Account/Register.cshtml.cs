using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RentABag.Models;
using RentABag.Services.Common;
using RentABag.Services.ValidationAttributes;
using RentABag.Web.Data;
using RentABag.Web.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace RentABag.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<RentABagUser> _signInManager;
        private readonly UserManager<RentABagUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IAddressesService _addressesService;
        private readonly RentABagDbContext _context;

        public RegisterModel(
            UserManager<RentABagUser> userManager,
            SignInManager<RentABagUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IAddressesService addressesService,
            RentABagDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _addressesService = addressesService;
            _context = context;
        }

        [BindProperty(Name = "Input")]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

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

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(IFormFile profilePicture, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var address = new Address
                {
                    PostCode = Input.PostCode,
                    ActualAddress = Input.ActualAddress,
                    City = Input.City,
                    Country = Input.Country
                };
                _addressesService.CreateAddressAsync(address);
                var user = new RentABagUser { UserName = Input.UserName, Email = Input.Email, FullName = Input.FullName, Address = address, Birthday = Input.Birthday, PhoneNumber = Input.PhoneNumber };
                var result1 = await _userManager.CreateAsync(user, Input.Password);
                var result2 = await _userManager.AddToRoleAsync(user, "User");
                var result3 = !_context.Users.Any(u => u.UserName == Input.UserName);
                if (result1.Succeeded && result2.Succeeded && result3)
                {
                    MigrateShoppingCart(Input.UserName);
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result1.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                foreach (var error in result2.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private void MigrateShoppingCart(string UserName)
        {
            // Associate shopping cart items with logged-in user
            var cart = ShoppingCart.GetCart(this.HttpContext, _context);

            cart.MigrateCart(UserName);
            //Session[ShoppingCart.CartSessionKey] = UserName;
        }
    }
}