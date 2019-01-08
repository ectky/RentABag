using System;
using System.ComponentModel.DataAnnotations;

namespace RentABag.Services.ValidationAttributes
{
    public class BirthdateAttribute : ValidationAttribute
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
                return new ValidationResult(ErrorMessage.Replace("{0}", years.ToString()));
            }

            return ValidationResult.Success;
        }
    }
}
