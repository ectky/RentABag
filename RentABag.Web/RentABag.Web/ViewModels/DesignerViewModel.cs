using RentABag.Models;
using RentABag.Services.Mapping;

namespace RentABag.Web.ViewModels
{
    public class DesignerViewModel : IMapTo<Designer>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }
    }
}