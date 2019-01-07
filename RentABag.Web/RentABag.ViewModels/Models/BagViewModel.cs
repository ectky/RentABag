using RentABag.Models;
using RentABag.Services.Mapping;
using System.Collections.Generic;

namespace RentABag.ViewModels
{
    public class BagViewModel : IMapTo<Bag>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal NewPrice => Price * (1 - DiscountPercent / 100);

        public string Description { get; set; }

        public string ShortDescription => Description.Substring(0, Description.Length > 30 ? 30 : Description.Length);

        public decimal DiscountPercent { get; set; }

        public byte[] Image { get; set; }

        public int DesignerId { get; set; }

        public string DesignerName { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int CollectionId { get; set; }

        public string CollectionName { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
