using System;
using System.Collections.Generic;
using System.Text;

namespace RentABag.Models
{
    public class Shop
    {
        public int Id { get; set; }

        public int ReviewId { get; set; }

        public virtual Review Review { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public decimal DiscountPercent { get; set; }

        public virtual ICollection<BagShop> BagShops { get; set; }

    }
}
