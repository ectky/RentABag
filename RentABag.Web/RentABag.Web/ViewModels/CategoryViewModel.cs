using RentABag.Models;
using RentABag.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.ViewModels
{
    public class CategoryViewModel : IMapTo<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Bag> Bags { get; set; }
    }
}
