using RentABag.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentABag.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}
