using AutoMapper;
using RentABag.Services.Mapping;
using RentABag.ViewModels;
using System.Linq;
using Xunit;

namespace RentABag.Services.Tests
{
    [Collection("CollectionName")]
    public class ShopsServiceTests
    {
        [Fact]
        public async void CreateAddressAsync_ShouldCreateAnAddressInDb()
        {
            // Arrange
            var dbContext = StaticMethods.GetDb();
            var addressesService = new AddressesService(dbContext);
            var shopsService = new ShopsService(dbContext, addressesService);
            var shopViewModel = new CreateShopViewModel()
            {
                ActualAddress = "ActualAddress",
                City = "City",
                Country = "Country",
                PostCode = "66666",
                Description = "Description",
                DiscountPercent = 10,
                Name = "Name",
                PhoneNumber = "PhoneNumbers"
            };
            //Act

            var shopId = await shopsService.CreateShopAsync(shopViewModel);
            var shopsCount = dbContext.Shops.Count();
            var addressesCount = dbContext.Addresses.Count();

            var shop = dbContext.Shops.Find(shopId);

            //Assert
            Assert.True(addressesCount == 1);
            Assert.True(shopsCount == 1);
            Assert.True(shop.Address.PostCode == shopViewModel.PostCode);
            Assert.True(shop.Address.City == shopViewModel.City);
            Assert.True(shop.Address.Country == shopViewModel.Country);
            Assert.True(shop.Address.ActualAddress == shopViewModel.ActualAddress);
            Assert.True(shop.Address.ShopId == shop.Id);
            Assert.True(shop.Address.OrderId == null);
            Assert.True(shop.Address.UserId == null);
            Assert.True(shop.Description == shop.Description);
            Assert.True(shop.DiscountPercent == shop.DiscountPercent);
            Assert.True(shop.Name == shop.Name);
            Assert.True(shop.PhoneNumber == shop.PhoneNumber);
        }

        [Fact]
        public async void GetShopById_ShouldReturnShop()
        {
            // Arrange
            var dbContext = StaticMethods.GetDb();
            var addressesService = new AddressesService(dbContext);
            var shopsService = new ShopsService(dbContext, addressesService);
            var shopViewModel = new CreateShopViewModel()
            {
                ActualAddress = "ActualAddress",
                City = "City",
                Country = "Country",
                PostCode = "66666",
                Description = "Description",
                DiscountPercent = 10,
                Name = "Name",
                PhoneNumber = "PhoneNumbers"
            };
            //Act

            var shopId = await shopsService.CreateShopAsync(shopViewModel);
            var shop = dbContext.Shops.Find(shopId);

            var getShop = shopsService.GetShopById(shopId);

            //Assert
            Assert.True(shop.Address.PostCode == getShop.Address.PostCode);
            Assert.True(shop.Address.City == getShop.Address.City);
            Assert.True(shop.Address.Country == getShop.Address.Country);
            Assert.True(shop.Address.ActualAddress == getShop.Address.ActualAddress);
            Assert.True(shop.Address.ShopId == getShop.Id);
            Assert.True(shop.Address.OrderId == null);
            Assert.True(shop.Address.UserId == null);
            Assert.True(shop.Description == getShop.Description);
            Assert.True(shop.DiscountPercent == getShop.DiscountPercent);
            Assert.True(shop.Name == getShop.Name);
            Assert.True(shop.PhoneNumber == getShop.PhoneNumber);
            Assert.True(shop.Id == getShop.Id);
        }

        [Fact]
        public async void DeleteAhopAsync_ShouldDeleteShopFromDb()
        {
            // Arrange
            var dbContext = StaticMethods.GetDb();
            var addressesService = new AddressesService(dbContext);
            var shopsService = new ShopsService(dbContext, addressesService);
            var shopViewModel = new CreateShopViewModel()
            {
                ActualAddress = "ActualAddress",
                City = "City",
                Country = "Country",
                PostCode = "66666",
                Description = "Description",
                DiscountPercent = 10,
                Name = "Name",
                PhoneNumber = "PhoneNumbers"
            };
            var shopId = await shopsService.CreateShopAsync(shopViewModel);
            //Act

            var shop = shopsService.GetShopById(shopId);
            shopsService.DeleteShopAsync(shop);
            var shopsCount = dbContext.Shops.Count();

            //Assert
            Assert.True(shopsCount == 0);
        }

        [Fact]
        public async void EditShopAsync_ShouldChangeProperiesOfShop()
        {
            var dbContext = StaticMethods.GetDb();
            var addressesService = new AddressesService(dbContext);
            var shopsService = new ShopsService(dbContext, addressesService);
            var shopViewModel1 = new CreateShopViewModel()
            {
                ActualAddress = "ActualAddress1",
                City = "City1",
                Country = "Country1",
                PostCode = "666661",
                Description = "Description1",
                DiscountPercent = 101,
                Name = "Name1",
                PhoneNumber = "PhoneNumbers1"
            };
            var shopId = await shopsService.CreateShopAsync(shopViewModel1);
            var shop = shopsService.GetShopById(shopId);

            var shopViewModel2 = new CreateShopViewModel()
            {
                ActualAddress = "ActualAddress2",
                City = "City2",
                Country = "Country2",
                PostCode = "666662",
                Description = "Description2",
                DiscountPercent = 102,
                Name = "Name2",
                PhoneNumber = "PhoneNumbers2"
            };
            //Act

            var shopId2 = await shopsService.EditShopAsync(shopViewModel2, shop);
            var shop2 = shopsService.GetShopById(shopId2);

            //Assert
            Assert.True(shop2.Address.PostCode == shopViewModel2.PostCode);
            Assert.True(shop2.Address.City == shopViewModel2.City);
            Assert.True(shop2.Address.Country == shopViewModel2.Country);
            Assert.True(shop2.Address.ActualAddress == shopViewModel2.ActualAddress);
            Assert.True(shop2.Address.ShopId == shop2.Id);
            Assert.True(shop2.Address.OrderId == null);
            Assert.True(shop2.Address.UserId == null);
            Assert.True(shop2.Description == shop.Description);
            Assert.True(shop2.DiscountPercent == shop.DiscountPercent);
            Assert.True(shop2.Name == shop.Name);
            Assert.True(shop2.PhoneNumber == shop.PhoneNumber);
        }

        [Fact]
        public async void GetAllShops_ShouldReturnAllShopsFromDb()
        {
            // Arrange
            Mapper.Reset();

            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var addressesService = new AddressesService(dbContext);
            var shopsService = new ShopsService(dbContext, addressesService);
            int count = 6;

            for (int i = 0; i < count; i++)
            {
                var shopViewModel = new CreateShopViewModel()
                {
                    ActualAddress = "ActualAddress",
                    City = "City",
                    Country = "Country",
                    PostCode = "66666",
                    Description = "Description",
                    DiscountPercent = 10,
                    Name = "Name",
                    PhoneNumber = "PhoneNumbers"
                };
            var shopId = await shopsService.CreateShopAsync(shopViewModel);
            }
            //Act

            var allShops = shopsService.GetAllShops();
            var shopsCount = dbContext.Shops.Count();

            //Assert
            Assert.True(count == shopsCount && count == allShops.Count());
        }
    }
}
