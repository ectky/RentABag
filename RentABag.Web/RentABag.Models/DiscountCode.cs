using System;

namespace RentABag.Models
{
    public class DiscountCode
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public decimal DiscountPercent { get; set; }
    }
}
