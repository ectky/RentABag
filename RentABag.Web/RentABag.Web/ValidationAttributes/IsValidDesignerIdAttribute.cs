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

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is DateTime))
            {
                return new ValidationResult("Invalid DateTime object.");
            }

            var dateTime = (DateTime)value;
            if (((DateTime.UtcNow - dateTime).TotalDays / 365.25) < years)
            {
                return new ValidationResult(this.ErrorMessage.Replace("{0}", years.ToString()));
            }

            return ValidationResult.Success;
        }
    }
}
