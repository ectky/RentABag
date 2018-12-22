using RentABag.Models;
using RentABag.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.ViewModels
{
    public class ShopViewModel : IMapTo<Shop>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public decimal DiscountPercent { get; set; }
        
        public string PhoneNumber { get; set; }

        public string Country { get; set; }
        
        public string City { get; set; }
        
        public string PostCode { get; set; }
        
        public string ActualAddress { get; set; }
    }
}
