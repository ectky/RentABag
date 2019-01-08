using RentABag.Models;
using RentABag.Services.Mapping;
using RentABag.Services.ValidationAttributes;
using RentABag.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace RentABag.Web.Models
{
    public class CreateBagViewModel : IMapTo<CreateBagOtherViewModel>, IMapTo<Bag>
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

        [Required]
        [Range(0.00, 100, ErrorMessage = "Discount Percent must be greater than 0.00")]
        [Display(Name = "Discount Percent")]
        public decimal DiscountPercent { get; set; }

        public byte[] Image { get; set; }

        [Required]
        [IsValidDesignerId]
        public int DesignerId { get; set; }

        [Required]
        [IsValidCategoryId]
        public int CategoryId { get; set; }

        [Required]
        [IsValidCollectionId]
        public int CollectionId { get; set; }

        //[Required]
        //public int ShopId { get; set; }        
    }
}
