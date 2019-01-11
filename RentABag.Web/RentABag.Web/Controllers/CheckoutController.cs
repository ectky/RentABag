using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentABag.Models;
using RentABag.Services.Common;
using RentABag.Web.Data;
using RentABag.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly IOrdersService ordersService;
        private readonly RentABagDbContext context;

        public CheckoutController(IOrdersService ordersService, RentABagDbContext context)
        {
            this.ordersService = ordersService;
            this.context = context;
        }

        public ActionResult AddressAndPayment()
        {
            return View();
        }

        public ActionResult Complete(int id)
        {
            return View(id);
        }

        [HttpPost]
        public async Task<ActionResult> AddressAndPayment(string code)
        {
            try
            {
                var cart = ShoppingCart.GetCart(this.HttpContext, context);
                
                var orderId = await this.ordersService.CreateOrderAsync(this.User.Identity.Name, code, cart.GetTotal(), cart.GetCartItems());
                cart.EmptyCart();

                return RedirectToAction("Complete","Checkout", new { id = orderId, area = "" });
            }
            catch
            {
                //Invalid - redisplay with errors
                return View();
            }
        }
    }
}
