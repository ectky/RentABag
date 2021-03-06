﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using RentABag.Models;
using RentABag.Services.Common;
using RentABag.Services.Mapping;
using RentABag.ViewModels;
using RentABag.Web.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Services
{
    public class BagsService : IBagsService
    {
        private readonly RentABagDbContext context;

        public BagsService(RentABagDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateBagAsync(CreateBagOtherViewModel vm, IFormFile file)
        {
            var bag = Mapper.Map<CreateBagOtherViewModel, Bag>(vm);

            if (file != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    bag.Image = memoryStream.ToArray();
                }
            }

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

        public async Task<int> EditBagAsync(CreateBagOtherViewModel vm, Bag bag, IFormFile file)
        {
            context.Attach(bag);
            if (file != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    bag.Image = memoryStream.ToArray();
                }
            }

            bag.Name = vm.Name;
            bag.Description = vm.Description;
            bag.DesignerId = vm.DesignerId;
            bag.CategoryId = vm.CategoryId;
            bag.Price = vm.Price;
            bag.DiscountPercent = vm.DiscountPercent;
            bag.CollectionId = vm.CollectionId;

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

        public ICollection<Bag> GetBagsForPage(int page, int bagsPerPage)
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

        public int GetPages(int bagsPerPage)
        {
            var pages = (context.Bags.Count() / bagsPerPage) + 1;

            return pages;
        }
    }
}
