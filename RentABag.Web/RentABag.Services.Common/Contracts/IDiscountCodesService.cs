using RentABag.Models;
using RentABag.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Services.Common
{
    public interface IDiscountCodesService
    {
        Task<int> CreateDiscountCodeAsync(CreateDiscountCodeViewModel vm);
        DiscountCode GetDiscountCodeById(int id);
        DiscountCode GetDiscountCodeByCode(string code);
        Task<int> EditDiscountCodeAsync(CreateDiscountCodeViewModel vm, DiscountCode discountCode);
        void DeleteDiscountCodeAsync(DiscountCode discountCode);
        ICollection<DiscountCode> GetAllDiscountCodes();
        bool ExistsDiscountCodeWithId(int id);
    }
}
