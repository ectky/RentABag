using RentABag.Models;
using RentABag.Services.Mapping;
using System;
using System.ComponentModel.DataAnnotations;

namespace RentABag.ViewModels
{
    public class CreateReviewViewModel : IMapTo<Review>
    {
        public DateTime GetDate { get; set; }

        public DateTime ReturnDate { get; set; }

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
        [Range(0, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }
    }
}
