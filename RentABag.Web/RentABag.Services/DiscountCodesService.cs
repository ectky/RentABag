using AutoMapper;
using RentABag.Models;
using RentABag.Services.Common;
using RentABag.Services.Mapping;
using RentABag.ViewModels;
using RentABag.Web.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Services
{
    public class DiscountCodesService : IDiscountCodesService
    {
        private readonly RentABagDbContext context;

        public DiscountCodesService(RentABagDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateDiscountCodeAsync(CreateDiscountCodeViewModel vm)
        {
            var discountCode = Mapper.Map<CreateDiscountCodeViewModel, DiscountCode>(vm);

            await context.DiscountCodes.AddAsync(discountCode);
            await context.SaveChangesAsync();

            int discountCodeId = discountCode.Id;

            return discountCodeId;
        }

        public async void DeleteDiscountCodeAsync(DiscountCode discountCode)
        {
            context.Remove(discountCode);
            await context.SaveChangesAsync();
        }

        public async Task<int> EditDiscountCodeAsync(CreateDiscountCodeViewModel vm, DiscountCode discountCode)
        {
            context.Attach(discountCode);

            discountCode.Code = vm.Code;
            discountCode.DiscountPercent = vm.DiscountPercent;

            await context.SaveChangesAsync();

            return discountCode.Id;
        }

        public bool ExistsDiscountCodeWithId(int id)
        {
            return context.DiscountCodes.Any(d => d.Id == id);
        }

        public ICollection<DiscountCode> GetAllDiscountCodes()
        {
            var discountCodes = context.DiscountCodes.ToList();

            return discountCodes;
        }

        public DiscountCode GetDiscountCodeByCode(string code)
        {
            var discountCode = context.DiscountCodes.FirstOrDefault(d => d.Code == code);

            return discountCode;
        }

        public DiscountCode GetDiscountCodeById(int id)
        {
            var discountCode = context.DiscountCodes.FirstOrDefault(d => d.Id == id);

            return discountCode;
        }
    }
}
