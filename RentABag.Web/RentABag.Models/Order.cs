using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentABag.Models
{
    public class Order
    {
        public int Id { get; set; }

        public Status Status { get; set; }

        public DateTime Orderdate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public int RentalDays { get; set; }

        public int BagId { get; set; }

        public virtual Bag Bag { get; set; }

        public int UserId { get; set; }

        public virtual RentABagUser User { get; set; }

        public int? DiscountCodeId { get; set; }

        public virtual DiscountCode DiscountCode { get; set; }

        [NotMapped]
        public decimal TotalPrice => (this.Bag.Price * this.RentalDays) * (1 - DiscountCode?.DiscountPercent ?? 0);
    }
}
