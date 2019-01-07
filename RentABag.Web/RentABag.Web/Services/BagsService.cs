using RentABag.Models;
using RentABag.Services.Mapping;
using RentABag.Web.Data;
using RentABag.Web.Services.Contracts;
using RentABag.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Services
{
    public class BagsService : IBagsService
    {
        private const int bagsPerPage = 12;
        private readonly RentABagDbContext context;

        public BagsService(RentABagDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateBagAsync(CreateBagViewModel vm)
        {
            var bag = new Bag()
            {
                Description = vm.Description,
                Name = vm.Name,
                CategoryId = vm.CategoryId,
                DesignerId = vm.DesignerId,
                Price = vm.Price
            };

            await this.context.Bags.AddAsync(bag);
            await this.context.SaveChangesAsync();

            int categoryId = bag.Id;

            return categoryId;
        }
        
        public async void DeleteBagAsync(Bag bag)
        {
            this.context.Remove(bag);
            await this.context.SaveChangesAsync();
        }

        public async Task<int> EditBagAsync(CreateBagViewModel vm, Bag bag)
        {
            this.context.Attach(bag);

            bag.Name = vm.Name;
            bag.Description = vm.Description;
            bag.DesignerId = vm.DesignerId;
            bag.CategoryId = vm.CategoryId;
            bag.Price = vm.Price;

            await this.context.SaveChangesAsync();

            return bag.Id;
        }
        
        public ICollection<BagViewModel> GetAllBags()
        {
            var bags = this.context.Bags
                .To<BagViewModel>()
                .ToList();

            return bags;
        }
        
        public Bag GetBagById(int id)
        {
            var bag = this.context.Bags.FirstOrDefault(d => d.Id == id);

            return bag;
        }

        public ICollection<Bag> GetBagsForPage(int page)
        {
            var bags = this.context.Bags.Skip((page - 1) * bagsPerPage).Take(bagsPerPage).ToArray();

            return bags;
        }

        public ICollection<Bag> GetBestSellers(int count)
        {
            if (count > this.context.Bags.Count())
            {
                return null;
            }

            var bags = this.context.Bags
                .OrderByDescending(b => b.Orders.Count)
                .Take(count).ToArray();

            return bags;
        }

        public Bag GetDealOfTheWeek()
        {
            var bag = this.context.Bags
                .OrderByDescending(b => b.DiscountPercent)
                .FirstOrDefault();

            return bag;
        }

        public int GetPages()
        {
            var pages = (this.context.Bags.Count() / bagsPerPage) + 1;

            return pages;
        }
    }
}
