using RentABag.Models;
using RentABag.Services.Mapping;
using System;
using System.Collections.Generic;

namespace RentABag.ViewModels
{
    public class CollectionViewModel : IMapTo<Collection>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<BagViewModel> Bags { get; set; }
    }
}
