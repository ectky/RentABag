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
    public class ShopsService : IShopsService
    {
        private readonly RentABagDbContext context;
        private readonly IAddressesService addressesService;

        public ShopsService(RentABagDbContext context, IAddressesService addressesService)
        {
            this.context = context;
            this.addressesService = addressesService;
        }

        public async Task<int> CreateShopAsync(CreateShopViewModel vm)
        {
            var address = new Address
            {
                PostCode = vm.PostCode,
                ActualAddress = vm.ActualAddress,
                City = vm.City,
                Country = vm.Country
            };

            this.addressesService.CreateAddressAsync(address);
            await this.context.SaveChangesAsync();

            var shop = new Shop()
            {
                Name = vm.Name,
                Description = vm.Description,
                AddressId = address.Id,
                DiscountPercent = vm.DiscountPercent,
                PhoneNumber = vm.PhoneNumber
            };

            await this.context.Shops.AddAsync(shop);

            address.ShopId = shop.Id;

            await this.context.SaveChangesAsync();

            int shopId = shop.Id;

            return shopId;
        }

        public async void DeleteShopAsync(Shop shop)
        {
            this.context.Remove(shop);
            await this.context.SaveChangesAsync();
        }

        public async Task<int> EditShopAsync(CreateShopViewModel vm, Shop shop)
        {
            var address = this.addressesService.GetAddressById(shop.AddressId);

            this.context.Attach(shop);

            address.ActualAddress = vm.ActualAddress;
            address.City = vm.City;
            address.Country = vm.Country;
            address.PostCode = vm.PostCode;

            this.context.Attach(shop);

            shop.Name = vm.Name;
            shop.Description = vm.Description;
            shop.DiscountPercent = vm.DiscountPercent;
            shop.AddressId = address.Id;
            shop.PhoneNumber = vm.PhoneNumber;

            await this.context.SaveChangesAsync();

            return shop.Id;
        }

        public IQueryable<ShopViewModel> GetAllShops()
        {
            var shops = this.context.Shops
                .To<ShopViewModel>();

            return shops;
        }

        public Shop GetShopById(int id)
        {
            var shop = this.context.Shops.FirstOrDefault(d => d.Id == id);

            return shop;
        }
    }
}
