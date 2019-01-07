using RentABag.Models;
using RentABag.Services.Mapping;
using System.Collections.Generic;

namespace RentABag.ViewModels
{
    public class CreateBagOtherViewModel : IMapTo<Bag>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
        
        public string Description { get; set; }

        public decimal DiscountPercent { get; set; }

        public byte[] Image { get; set; }

        public int DesignerId { get; set; }

        public string DesignerName { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int CollectionId { get; set; }

        public string CollectioName { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
