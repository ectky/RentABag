using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentABag.Models
{
    public class Bag
    {
        public Bag()
        {
            this.BagOrders = new HashSet<BagOrder>();
            this.BagShops = new HashSet<BagShop>();
            this.Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public decimal DiscountPercent { get; set; }

        public byte[] Image { get; set; }

        public int? DesignerId { get; set; }

        public virtual Designer Designer { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int? CollectionId { get; set; }

        public virtual Collection Collection { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<BagOrder> BagOrders { get; set; }

        public virtual ICollection<BagShop> BagShops { get; set; }

        [NotMapped]
        public decimal NewPrice => Math.Round(Price * (1 - DiscountPercent / 100), 2);
    }
}
