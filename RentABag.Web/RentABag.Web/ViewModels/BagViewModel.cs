using RentABag.Models;
using RentABag.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.ViewModels
{
    public class BagViewModel : IMapTo<Bag>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal NewPrice => this.Price * (1 - this.DiscountPercent / 100);

        public string Description { get; set; }

        public string ShortDescription => Description.Substring(0, this.Description.Length > 30 ? 30 : this.Description.Length);

        public decimal DiscountPercent { get; set; }

        public byte[] Image { get; set; }

        public int DesignerId { get; set; }

        public string Designer { get; set; }

        public int CategoryId { get; set; }

        public string Category { get; set; }

        public int CollectionId { get; set; }

        public string Collection { get; set; }
    }
}
