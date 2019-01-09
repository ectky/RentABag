using Microsoft.AspNetCore.Mvc;
using RentABag.Services.Common;
using RentABag.ViewModels;
using RentABag.Web.Data;
using RentABag.Web.Helpers;
using RentABag.Web.Models;
using System;
using System.Linq;
using System.Text.Encodings.Web;

namespace RentABag.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly RentABagDbContext context;
        private readonly IBagsService bagsService;

        public CartController(RentABagDbContext context, IBagsService bagsService)
        {
            this.context = context;
            this.bagsService = bagsService;
        }

        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(HttpContext, context);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }
        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id, DateTime getDate, DateTime returnDate)
        {
            // Retrieve the album from the database
            var addedBag = bagsService.GetBagById(id);

            if (addedBag == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            if (getDate > returnDate || getDate == returnDate || returnDate <= DateTime.Now)
            {
                return RedirectToAction(Constants.detailsName, Constants.bagName, new { id = id, area = Constants.administratorRole });
            }

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(HttpContext, context);

            try
            {
                cart.AddToCart(addedBag, getDate, returnDate);
            }
            catch
            {
                return RedirectToAction(Constants.detailsName, Constants.bagName, new { id = id, area = Constants.administratorRole });
            }

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }
        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id, DateTime getDate, DateTime returnDate)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(HttpContext, context);

            // Get the name of the album to display confirmation
            string bagName = context.Carts
                .Single(item => item.RecordId == id).Bag.Name;

            int itemCount = 0;

            try
            {
                // Remove from cart
                itemCount = cart.RemoveFromCart(id, getDate, returnDate);
            }
            catch
            {
                return RedirectToAction(Constants.detailsName, Constants.bagName, new
                {
                    id = id,
                    area = Constants.administratorRole
                });
            }

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = HtmlEncoder.Default.Encode(bagName) +
                                " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                ItemCount = itemCount,
                DeleteId = id
            };

            return Json(results);
        }

        //
        // GET: /ShoppingCart/CartSummary
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(HttpContext, context);

            return PartialView("CartSummary");
        }
    }
}
