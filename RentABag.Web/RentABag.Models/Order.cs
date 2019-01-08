using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RentABag.Models
{
    public class Order
    {
        public Order()
        {
            this.BagOrders = new HashSet<BagOrder>();
        }

        public int Id { get; set; }

        public int? AddressId { get; set; }

        public virtual Address Address { get; set; }

        public Status Status { get; set; }

        public DateTime Orderdate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public int RentalDays { get; set; }

        public int UserId { get; set; }

        public virtual RentABagUser User { get; set; }

        public int? DiscountCodeId { get; set; }

        public virtual DiscountCode DiscountCode { get; set; }

        public int ShopId { get; set; }

        public virtual Shop Shop { get; set; }

        public virtual ICollection<BagOrder> BagOrders { get; set; }

        [NotMapped]
        public decimal TotalPrice => (this.BagOrders.Sum(bo => bo.Bag.Price) * this.RentalDays) * (1 - DiscountCode?.DiscountPercent ?? 0);
    }
}
