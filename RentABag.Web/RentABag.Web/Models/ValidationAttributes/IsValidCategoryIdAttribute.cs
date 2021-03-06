﻿using RentABag.Services.Common;
using System.ComponentModel.DataAnnotations;

namespace RentABag.Services.ValidationAttributes
{
    public class IsValidCategoryIdAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var designersService = (ICategoriesService)validationContext.GetService(typeof(ICategoriesService));
            int id = 0;

            if (!int.TryParse(value.ToString(), out id))
            {
                return new ValidationResult("Invalid Category.");
            }

            if (!designersService.ExistsCategoryWithId(id))
            {
                return new ValidationResult("Category with this id does not exist.");
            }

            return ValidationResult.Success;
        }
    }
}
