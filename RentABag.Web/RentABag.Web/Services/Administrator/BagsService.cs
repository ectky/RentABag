using AutoMapper;
using RentABag.Models;
using RentABag.Services.Common;
using RentABag.Services.Mapping;
using RentABag.ViewModels;
using RentABag.Web.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Services.Administrator
{
    public class BagsService : IBagsService
    {
        private const int bagsPerPage = 12;
        private readonly RentABagDbContext context;

        public BagsService(RentABagDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateBagAsync(CreateBagOtherViewModel vm)
        {
            var bag = Mapper.Map<CreateBagOtherViewModel, Bag>(vm);

            await context.Bags.AddAsync(bag);
            await context.SaveChangesAsync();

            int categoryId = bag.Id;

            return categoryId;
        }

        public async void DeleteBagAsync(Bag bag)
        {
            context.Remove(bag);
            await context.SaveChangesAsync();
        }

        public async Task<int> EditBagAsync(CreateBagOtherViewModel vm, Bag bag)
        {
            context.Attach(bag);

            bag.Name = vm.Name;
            bag.Description = vm.Description;
            bag.DesignerId = vm.DesignerId;
            bag.CategoryId = vm.CategoryId;
            bag.Price = vm.Price;

            await context.SaveChangesAsync();

            return bag.Id;
        }

        public ICollection<BagViewModel> GetAllBags()
        {
            var bags = context.Bags
                .To<BagViewModel>()
                .ToList();

            return bags;
        }

        public Bag GetBagById(int id)
        {
            var bag = context.Bags.FirstOrDefault(d => d.Id == id);

            return bag;
        }

        public ICollection<Bag> GetBagsForPage(int page)
        {
            var bags = context.Bags.Skip((page - 1) * bagsPerPage).Take(bagsPerPage).ToArray();

            return bags;
        }

        public ICollection<Bag> GetBestSellers(int count)
        {
            if (count > context.Bags.Count())
            {
                return null;
            }

            var bags = context.Bags
                .OrderByDescending(b => b.BagOrders.Count)
                .Take(count).ToArray();

            return bags;
        }

        public Bag GetDealOfTheWeek()
        {
            var bag = context.Bags
                .OrderByDescending(b => b.DiscountPercent)
                .FirstOrDefault();

            return bag;
        }

        public int GetPages()
        {
            var pages = (context.Bags.Count() / bagsPerPage) + 1;

            return pages;
        }
    }
}
