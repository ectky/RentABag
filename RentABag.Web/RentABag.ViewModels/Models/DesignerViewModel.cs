using RentABag.Models;
using RentABag.Services.Mapping;
using System.Collections.Generic;

namespace RentABag.ViewModels
{
    public class DesignerViewModel : IMapTo<Designer>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public ICollection<Bag> Bags { get; set; }

    }
}