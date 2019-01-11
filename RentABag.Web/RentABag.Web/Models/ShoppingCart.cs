using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentABag.Helpers;
using RentABag.Models;
using RentABag.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentABag.Web.Models
{
    public class ShoppingCart
    {
        private readonly RentABagDbContext storeDB;

        public ShoppingCart(RentABagDbContext storeDB)
        {
            this.storeDB = storeDB;
        }

        string ShoppingCartId { get; set; }


        public static ShoppingCart GetCart(HttpContext context, RentABagDbContext store)
        {
            var cart = new ShoppingCart(store);
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller, RentABagDbContext store)
        {
            return GetCart(controller.HttpContext, store);
        }

        public void AddToCart(Bag bag, DateTime getDate, DateTime returnDate)
        {
            // Get the matching cart and album instances
            var cartItem = storeDB.Carts.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.BagId == bag.Id
                && ((c.GetDate <= getDate && c.ReturnDate >= getDate)
                || (c.GetDate <= returnDate && c.ReturnDate >= returnDate)
                || (c.GetDate >= getDate && c.ReturnDate <= returnDate)));

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Cart
                {
                    BagId = bag.Id,
                    CartId = ShoppingCartId,
                    DateCreated = DateTime.Now,
                    GetDate = getDate,
                    ReturnDate = returnDate,
                    RentalDays = (returnDate - getDate).Days + 1
                };
                storeDB.Carts.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                throw new InvalidOperationException("You cant't order a bag for the same time twice.");
            }
            // Save changes
            storeDB.SaveChanges();
        }
        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = storeDB.Carts.Single(
                c => c.CartId == ShoppingCartId
                && c.RecordId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                storeDB.Carts.Remove(cartItem);

                // Save changes
                storeDB.SaveChanges();
            }

            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = storeDB.Carts.Where(
                cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                storeDB.Carts.Remove(cartItem);
            }
            // Save changes
            storeDB.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            return storeDB.Carts.Where(
                cart => cart.CartId == ShoppingCartId).ToList();
        }

        //public int GetCount()
        //{
        //    // Get the count of each item in the cart and sum them up
        //    int? count = (from cartItems in storeDB.Carts
        //                  where cartItems.Id == ShoppingCartId
        //                  select (int?)cartItems.Count).Sum();
        //    // Return 0 if all entries are null
        //    return count ?? 0;
        //}

        public decimal GetTotal()
        {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            decimal? total = storeDB.Carts.Where(cart => cart.CartId == ShoppingCartId).Sum(c => (c.Bag.Price * (1 - c.Bag.DiscountPercent / 100)) * c.RentalDays);

            var result = total ?? decimal.Zero;

            return Math.Round(result, 2);
        }

        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new BagOrder
                {
                    BagId = item.BagId,
                    OrderId = order.Id,
                    GetDate = item.GetDate,
                    ReturnDate = item.ReturnDate,
                    RentalDays = (item.ReturnDate - item.GetDate).Days + 1
                };
                // Set the order total of the shopping cart
                orderTotal += (item.Bag.Price);

                storeDB.BagOrders.Add(orderDetail);

            }
            // Set the order's total to the orderTotal count
            order.Total = orderTotal;

            // Save the order
            storeDB.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return order.Id;
        }
        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContext context)
        {
            if (context.Session.GetString(Constants.CartSessionKey) == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session.SetString(Constants.CartSessionKey, context.User.Identity.Name);
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session.SetString(Constants.CartSessionKey, tempCartId.ToString());
                }
            }
            return context.Session.GetString(Constants.CartSessionKey);
        }

        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = storeDB.Carts.Where(
                c => c.CartId == ShoppingCartId);

            foreach (Cart item in shoppingCart)
            {
                item.CartId = userName;
            }
            storeDB.SaveChanges();
        }
    }
}
