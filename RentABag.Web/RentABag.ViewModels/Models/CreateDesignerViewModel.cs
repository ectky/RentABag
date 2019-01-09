using AutoMapper;
using Microsoft.AspNetCore.Http;
using RentABag.Models;
using RentABag.Services.Mapping;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace RentABag.ViewModels
{
    public class CreateDesignerViewModel : IMapTo<Designer>
    {
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Full Name")]
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Description")]
        public string Description { get; set; }
        
        public byte[] Image { get; set; }
    }
}
