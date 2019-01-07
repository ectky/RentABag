using RentABag.Models;
using RentABag.Services.Mapping;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentABag.ViewModels
{
    public class CreateCollectionOtherViewModel : IMapTo<Collection>
    {
        
        public string Name { get; set; }

        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
    }
}
