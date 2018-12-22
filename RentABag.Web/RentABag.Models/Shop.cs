using System.Collections.Generic;

namespace RentABag.Models
{
    public class Shop
    {
        public Shop()
        {
            this.BagShops = new HashSet<BagShop>();
            this.Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public decimal DiscountPercent { get; set; }

        public virtual ICollection<BagShop> BagShops { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
