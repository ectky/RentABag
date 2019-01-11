using RentABag.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RentABag.Services.Common
{
    public interface IOrdersService
    {
        Task<int> CreateOrderAsync(string name, string code, decimal total, ICollection<Cart> cartItems);
    }
}
