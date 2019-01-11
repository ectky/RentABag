using RentABag.Models;
using RentABag.Services.Common;
using RentABag.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly RentABagDbContext context;
        private readonly IDiscountCodesService discountCodesService;

        public OrdersService(RentABagDbContext context, IDiscountCodesService discountCodesService)
        {
            this.context = context;
            this.discountCodesService = discountCodesService;
        }

        public async Task<int> CreateOrderAsync(string name, string code, decimal total, ICollection<Cart> cartItems)
        {
            var user = context.Users.FirstOrDefault(u => u.UserName == name);

            if (user == null)
            {
                throw new InvalidOperationException();
            }

            var discountCode = discountCodesService.GetDiscountCodeByCode(code);
            int? discountCodeId = null;

            if (discountCode != null)
            {
                discountCodeId = discountCode.Id;
            }

            var order = new Order()
            {
                AddressId = user.Address.Id,
                DiscountCodeId = discountCodeId,
                UserId = user.Id,
                Total = total,
                Status = Status.Shipping
            };

            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();

            var bagOrders = cartItems.Select(c => new BagOrder
            {
                BagId = c.BagId,
                GetDate = c.GetDate,
                OrderId = order.Id,
                ReturnDate = c.ReturnDate,
                RentalDays = (c.ReturnDate - c.GetDate).Days + 1
            }).ToList();

            await context.BagOrders.AddRangeAsync(bagOrders);
            await context.SaveChangesAsync();

            order.BagOrders = bagOrders;

            await context.SaveChangesAsync();

            return order.Id;
        }
    }
}
