using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace RentABag.Models
{
    public class Bag
    {
        public Bag()
        {
            this.Orders = new HashSet<Order>();
            this.Reviews = new HashSet<Review>();
            this.BagShops = new HashSet<BagShop>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public decimal DiscountPercent { get; set; }

        public byte[] Image { get; set; }

        public int DesignerId { get; set; }

        public virtual Designer Designer { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int? CollectionId { get; set; }

        public virtual Collection Collection { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<BagShop> BagShops { get; set; }


    }
}
