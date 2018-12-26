using RentABag.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.ValidationAttributes
{
    public class IsValidDesignerIdAttribute : ValidationAttribute
    {
        private const int years = 18;
        private readonly IDesignersService designersService;

        public IsValidDesignerIdAttribute(IDesignersService designersService)
        {
            this.designersService = designersService;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int id = 0;

            if (int.TryParse(value.ToString(), out id))
            {
                return new ValidationResult("Invalid Designer Id.");
            }


            if (this.designersService.ExistsDesignerWithId(id))
            {
                return new ValidationResult("Designer with this id does not exist.");
            }

            return ValidationResult.Success;
        }
    }
}
