using RentABag.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.ValidationAttributes
{
    public class IsValidCollectionIdAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var collectionsService = (ICollectionsService)validationContext.GetService(typeof(ICollectionsService));
            int id = 0;

            if (!int.TryParse(value.ToString(), out id))
            {
                return new ValidationResult("Invalid Collection.");
            }

            if (!collectionsService.ExistsCollectionWithId(id))
            {
                return new ValidationResult("Collection with this id does not exist.");
            }

            return ValidationResult.Success;
        }
    }
}
