﻿using RentABag.Web.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.ViewModels
{
    public class CreateBagViewModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 999999999, ErrorMessage = "Price must be greater than 0.00")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public byte[] Image { get; set; }

        [Required]
        [IsValidDesignerId]
        public int DesignerId { get; set; }

        [Required]
        //[IsValidCategoryId]
        public int CategoryId { get; set; }

        [Required]
        //[IsValidShopId]
        public int ShopId { get; set; }        
    }
}