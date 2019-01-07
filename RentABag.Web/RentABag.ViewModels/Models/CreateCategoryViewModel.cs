using RentABag.Models;
using RentABag.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace RentABag.ViewModels
{
    public class CreateCategoryViewModel : IMapTo<Category>
    {
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
