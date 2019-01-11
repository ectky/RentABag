using RentABag.Models;
using RentABag.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentABag.ViewModels
{
    public class CreateDiscountCodeViewModel : IMapTo<DiscountCode>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Range(0.01, 100, ErrorMessage = "Discount Percent must be greater than 0.00")]
        [Display(Name = "Discount Percent")]
        public decimal DiscountPercent { get; set; }
    }
}
