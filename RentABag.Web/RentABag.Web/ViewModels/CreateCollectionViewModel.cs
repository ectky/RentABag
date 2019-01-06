using RentABag.Models;
using RentABag.Services.Mapping;
using RentABag.Web.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.ViewModels
{
    public class CreateCollectionViewModel : IMapTo<Collection>
    {
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DateGreaterThan(otherPropertyName = "StartDate", ErrorMessage = "End date must be greater than start date")]
        public DateTime EndDate { get; set; }
    }
}
