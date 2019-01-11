using AutoMapper;
using RentABag.Services.Mapping;
using RentABag.ViewModels;
using System.Linq;
using Xunit;

namespace RentABag.Services.Tests
{
    [Collection("CollectionName")]
    public class BagsServiceTests
    {
        [Fact]
        public async void CreateBagAsync_ShouldCreateABagInDb()
        {
            // Arrange
            Mapper.Reset();

            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var bagsService = new BagsService(dbContext);
            var bagViewModel = new CreateBagOtherViewModel()
            {
                Description = "Description",
                Name = "Name",
                DiscountPercent = 10,
                Price = 200
            };
            //Act

            var bagId = await bagsService.CreateBagAsync(bagViewModel, null);
            var bagsCount = dbContext.Bags.Count();

            var bag = dbContext.Bags.Find(bagId);

            //Assert
            Assert.True(bagsCount == 1);
            Assert.True(bag.Description == bag.Description);
            Assert.True(bag.Name == bag.Name);
        }

        [Fact]
        public async void GetBagById_ShouldReturnBag()
        {
            // Arrange
            Mapper.Reset();
            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var bagsService = new BagsService(dbContext);
            var bagViewModel = new CreateBagOtherViewModel()
            {
                Description = "Description",
                Name = "Name",
                DiscountPercent = 10,
                Price = 200
            };
            //Act

            var bagId = await bagsService.CreateBagAsync(bagViewModel, null);
            var bag = dbContext.Bags.Find(bagId);

            var getBag = bagsService.GetBagById(bagId);

            //Assert
            Assert.True(bag.Description == getBag.Description);
            Assert.True(bag.Name == getBag.Name);
            Assert.True(bag.DiscountPercent == getBag.DiscountPercent);
            Assert.True(bag.Price == getBag.Price);
            Assert.True(bag.Id == getBag.Id);
        }

        [Fact]
        public async void DeleteBagAsync_ShouldDeleteBagFromDb()
        {
            // Arrange
            Mapper.Reset();
            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var bagsService = new BagsService(dbContext);
            var bagViewModel = new CreateBagOtherViewModel()
            {
                Description = "Description",
                Name = "Name",
                DiscountPercent = 10,
                Price = 200
            };
            var bagId = await bagsService.CreateBagAsync(bagViewModel, null);
            //Act

            var bag = bagsService.GetBagById(bagId);
            bagsService.DeleteBagAsync(bag);
            var bagsCount = dbContext.Bags.Count();

            //Assert
            Assert.True(bagsCount == 0);
        }

        [Fact]
        public async void EditBagAsync_ShouldChangeProperiesOfBag()
        {
            Mapper.Reset();
            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var bagsService = new BagsService(dbContext);
            var bagViewModel = new CreateBagOtherViewModel()
            {
                Description = "Description",
                Name = "Name",
                DiscountPercent = 10,
                Price = 200
            };
            var bagId = await bagsService.CreateBagAsync(bagViewModel, null);
            var bag = bagsService.GetBagById(bagId);

            var bagViewModel2 = new CreateBagOtherViewModel()
            {
                Description = "Description2",
                Name = "Name2",
                DiscountPercent = 102,
                Price = 2002
            };
            //Act

            var bagId2 = await bagsService.EditBagAsync(bagViewModel2, bag, null);
            var bag2 = bagsService.GetBagById(bagId2);

            //Assert
            Assert.True(bag2.Description == bag.Description);
            Assert.True(bag2.Name == bag.Name);
        }

        //[Fact]
        //public async void GetAllBags_ShouldReturnAllBagsFromDb()
        //{
        //    // Arrange
        //    Mapper.Reset();

        //    AutoMapperConfig.RegisterMappings(
        //        typeof(CreateDesignerViewModel).Assembly
        //        );
        //    var dbContext = StaticMethods.GetDb();
        //    var bagsService = new BagsService(dbContext);

        //    int count = 6;

        //    for (int i = 0; i < count; i++)
        //    {
        //        var bagViewModel = new CreateBagOtherViewModel()
        //        {
        //            Description = "Description",
        //            Name = "Name",
        //            DiscountPercent = 10,
        //            Price = 200
        //        };

        //        var bagId = await bagsService.CreateBagAsync(bagViewModel, null);
        //    }
        //    //Act

        //    var allBags = bagsService.GetAllBags();
        //    var bagsCount = dbContext.Bags.Count();

        //    //Assert
        //    Assert.True(count == bagsCount && count == allBags.Count());
        //}

        [Fact]
        public async void GetBestSellers_ShouldReturnBestSellersFromDb()
        {
            // Arrange
            Mapper.Reset();

            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var bagsService = new BagsService(dbContext);

            int count = 6;

            for (int i = 0; i < count; i++)
            {
                var bagViewModel = new CreateBagOtherViewModel()
                {
                    Description = "Description",
                    Name = "Name",
                    DiscountPercent = 10,
                    Price = 200
                };

                var bagId = await bagsService.CreateBagAsync(bagViewModel, null);
            }
            int bestSellersCount = 2;
            //Act

            var bestSellers = bagsService.GetBestSellers(bestSellersCount);

            //Assert
            Assert.True(bestSellersCount == bestSellers.Count());
        }

        [Fact]
        public async void GetBestSellersMoreThanBagsInDb_ShouldReturnNull()
        {
            // Arrange
            Mapper.Reset();

            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var bagsService = new BagsService(dbContext);

            int count = 6;

            for (int i = 0; i < count; i++)
            {
                var bagViewModel = new CreateBagOtherViewModel()
                {
                    Description = "Description",
                    Name = "Name",
                    DiscountPercent = 10,
                    Price = 200
                };

                var bagId = await bagsService.CreateBagAsync(bagViewModel, null);
            }
            int bestSellersCount = count +1;
            //Act

            var bestSellers = bagsService.GetBestSellers(bestSellersCount);

            //Assert
            Assert.True(bestSellers == null);
        }

        [Fact]
        public async void GetDealOfTheWeek_ShouldReturnBagWithBiggestDiscountPercentFromDb()
        {
            // Arrange
            Mapper.Reset();

            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var bagsService = new BagsService(dbContext);

            int count = 6;

            for (int i = 0; i < count; i++)
            {
                var bagViewModel = new CreateBagOtherViewModel()
                {
                    Description = "Description",
                    Name = "Name",
                    DiscountPercent = 10 + i,
                    Price = 200
                };

                var bagId = await bagsService.CreateBagAsync(bagViewModel, null);
            }
            int discountPercent = 15;
            //Act

            var dealOfTheWeek = bagsService.GetDealOfTheWeek();

            //Assert
            Assert.True(dealOfTheWeek.DiscountPercent == discountPercent);
        }

        [Fact]
        public async void GetPages_ShouldReturnIntPages()
        {
            // Arrange
            Mapper.Reset();

            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var bagsService = new BagsService(dbContext);

            int count = 30;

            for (int i = 0; i < count; i++)
            {
                var bagViewModel = new CreateBagOtherViewModel()
                {
                    Description = "Description",
                    Name = "Name",
                    DiscountPercent = 10,
                    Price = 200
                };

                var bagId = await bagsService.CreateBagAsync(bagViewModel, null);
            }
            int bagsPerPage = 12;
            int pagesToGet = 3;
            //Act

            var pages = bagsService.GetPages(bagsPerPage);

            //Assert
            Assert.True(pagesToGet == pages);
        }
    }
}
