using RentABag.Models;
using RentABag.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.ViewModels
{
    public class CreateReviewViewModel : IMapTo<Review>
    {
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Full Name")]
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Review")]
        public string Comment { get; set; }

        [Required]
        [Display(Name = "Rating")]
        [Range(0,5,ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }
    }
}
