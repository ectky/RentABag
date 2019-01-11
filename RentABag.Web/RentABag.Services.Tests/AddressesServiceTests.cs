using Microsoft.EntityFrameworkCore;
using RentABag.Web.Data;
using RentABag.Services;
using System;
using Xunit;
using RentABag.Models;

namespace RentABag.Services.Tests
{
    public class AddressesServiceTests
    {
        [Fact]
        public async void CreateAddressAsync_ShouldCreateAnAddressInDb()
        {
            // Arrange
            var dbContext = StaticMethods.GetDb();
            var addressesService = new AddressesService(dbContext);
            var address = new Address()
            {
                ActualAddress = "ActualAddress",
                City = "City",
                Country = "Country",
                PostCode = "66666"
            };
            //Act

            addressesService.CreateAddressAsync(address);
            var count = await dbContext.Addresses.CountAsync();

            //Assert
            Assert.True(count == 1);
        }

        [Fact]
        public void GetAddressById_ShouldReturnAddress()
        {
            // Arrange
            var dbContext = StaticMethods.GetDb();
            var addressesService = new AddressesService(dbContext);
            var address = new Address()
            {
                ActualAddress = "ActualAddress",
                City = "City",
                Country = "Country",
                PostCode = "66666"
            };
            //Act

            dbContext.Addresses.Add(address);
            dbContext.SaveChanges();

            var getAddress = addressesService.GetAddressById(address.Id);

            //Assert
            Assert.True(getAddress.PostCode == address.PostCode);
            Assert.True(getAddress.City == address.City);
            Assert.True(getAddress.Country == address.Country);
            Assert.True(getAddress.ActualAddress == address.ActualAddress);
            Assert.True(getAddress.Id == address.Id);
            Assert.True(getAddress.OrderId == address.OrderId);
            Assert.True(getAddress.ShopId == address.ShopId);
            Assert.True(getAddress.UserId == address.UserId);
        }
    }
}
