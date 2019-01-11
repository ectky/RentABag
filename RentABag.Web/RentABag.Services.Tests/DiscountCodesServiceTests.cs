using AutoMapper;
using RentABag.Services.Mapping;
using RentABag.ViewModels;
using System.Linq;
using Xunit;

namespace RentABag.Services.Tests
{
    [Collection("CollectionName")]
    public class DiscountCodesServiceTests
    {
        [Fact]
        public async void CreateDiscountCodeAsync_ShouldCreateADiscountCodeInDb()
        {
            // Arrange
            Mapper.Reset();

            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var discountCodesService = new DiscountCodesService(dbContext);
            var discountCodeViewModel = new CreateDiscountCodeViewModel()
            {
                Code = "Code",
                DiscountPercent = 10                
            };
            //Act

            var discountCodeId = await discountCodesService.CreateDiscountCodeAsync(discountCodeViewModel);
            var discountsCount = dbContext.DiscountCodes.Count();

            var discounts = dbContext.DiscountCodes.Find(discountCodeId);

            //Assert
            Assert.True(discountsCount == 1);
            Assert.True(discounts.Code == discounts.Code);
            Assert.True(discounts.DiscountPercent == discounts.DiscountPercent);
        }

        [Fact]
        public async void GetDiscountCodeById_ShouldReturnDiscountCode()
        {
            // Arrange
            Mapper.Reset();

            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var discountCodesService = new DiscountCodesService(dbContext);
            var discountCodeViewModel = new CreateDiscountCodeViewModel()
            {
                Code = "Code",
                DiscountPercent = 10
            };
            //Act

            var discountCodeId = await discountCodesService.CreateDiscountCodeAsync(discountCodeViewModel);
            var discountcide = dbContext.DiscountCodes.Find(discountCodeId);

            var getDiscount = discountCodesService.GetDiscountCodeById(discountCodeId);

            //Assert
            Assert.True(discountcide.Code == getDiscount.Code);
            Assert.True(discountcide.DiscountPercent == getDiscount.DiscountPercent);
            Assert.True(discountcide.Id == getDiscount.Id);
        }

        [Fact]
        public async void GetDiscountCodeByCode_ShouldReturnDiscountCode()
        {
            // Arrange
            Mapper.Reset();

            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var discountCodesService = new DiscountCodesService(dbContext);
            var discountCodeViewModel = new CreateDiscountCodeViewModel()
            {
                Code = "Code",
                DiscountPercent = 10
            };
            var code = "Code";
            //Act

            var discountCodeId = await discountCodesService.CreateDiscountCodeAsync(discountCodeViewModel);
            var discountcide = dbContext.DiscountCodes.Find(discountCodeId);

            var getDiscount = discountCodesService.GetDiscountCodeByCode(code);

            //Assert
            Assert.True(discountcide.Code == getDiscount.Code);
            Assert.True(discountcide.DiscountPercent == getDiscount.DiscountPercent);
            Assert.True(discountcide.Id == getDiscount.Id);
        }

        [Fact]
        public async void DeleteDiscountCodeAsync_ShouldDeleteDiscountCodeFromDb()
        {
            // Arrange
            Mapper.Reset();

            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var discountCodesService = new DiscountCodesService(dbContext);
            var discountCodeViewModel = new CreateDiscountCodeViewModel()
            {
                Code = "Code",
                DiscountPercent = 10
            };
            var discountCodeId = await discountCodesService.CreateDiscountCodeAsync(discountCodeViewModel);
            //Act

            var discounCode = discountCodesService.GetDiscountCodeById(discountCodeId);
            discountCodesService.DeleteDiscountCodeAsync(discounCode);
            var categoriesCount = dbContext.DiscountCodes.Count();

            //Assert
            Assert.True(categoriesCount == 0);
        }

        [Fact]
        public async void EditDiscountCodeAsync_ShouldChangeProperiesOfDiscountCode()
        {
            Mapper.Reset();

            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var discountCodesService = new DiscountCodesService(dbContext);
            var discountCodeViewModel = new CreateDiscountCodeViewModel()
            {
                Code = "Code",
                DiscountPercent = 10
            };
            var discountCodeId = await discountCodesService.CreateDiscountCodeAsync(discountCodeViewModel);
            var discount = discountCodesService.GetDiscountCodeById(discountCodeId);
            
            var categorydiscountCodel2 = new CreateDiscountCodeViewModel()
            {
                Code = "Code2",
                DiscountPercent = 102
            };
            //Act

            var discountId2 = await discountCodesService.EditDiscountCodeAsync(categorydiscountCodel2, discount);
            var category2 = discountCodesService.GetDiscountCodeById(discountId2);

            //Assert
            Assert.True(category2.Code == discount.Code);
            Assert.True(category2.DiscountPercent == discount.DiscountPercent);
        }

        [Fact]
        public async void GetAllDiscountCodes_ShouldReturnAllDiscountCodesFromDb()
        {
            // Arrange
            Mapper.Reset();

            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var discountCodesService = new DiscountCodesService(dbContext);

            int count = 6;

            for (int i = 0; i < count; i++)
            {
                var discountCodeViewModel = new CreateDiscountCodeViewModel()
                {
                    Code = "Code",
                    DiscountPercent = 10
                };
                //Act

                var discountCodeId = await discountCodesService.CreateDiscountCodeAsync(discountCodeViewModel);
            }
            //Act

            var allDiscount = discountCodesService.GetAllDiscountCodes();
            var categoriesCount = dbContext.DiscountCodes.Count();

            //Assert
            Assert.True(count == categoriesCount && count == allDiscount.Count());
        }

        [Fact]
        public async void ExistsDiscountCodeWithId_ShouldReturnTrue()
        {
            // Arrange
            Mapper.Reset();

            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var discountCodesService = new DiscountCodesService(dbContext);
            var discountCodeViewModel = new CreateDiscountCodeViewModel()
            {
                Code = "Code",
                DiscountPercent = 10
            };
            var discountCodeId = await discountCodesService.CreateDiscountCodeAsync(discountCodeViewModel);
            //Act
            
            var getDiscountId = discountCodesService.ExistsDiscountCodeWithId(discountCodeId);

            //Assert
            Assert.True(getDiscountId);
        }

        [Fact]
        public async void ExistsDiscountCodeWithWrongId_ShouldReturnFalse()
        {
            // Arrange
            Mapper.Reset();

            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var discountCodesService = new DiscountCodesService(dbContext);
            var discountCodeViewModel = new CreateDiscountCodeViewModel()
            {
                Code = "Code",
                DiscountPercent = 10
            };
            var discountCodeId = await discountCodesService.CreateDiscountCodeAsync(discountCodeViewModel);
            int wrongId = 150;
            //Act

            var getDiscountId = discountCodesService.ExistsDiscountCodeWithId(wrongId);

            //Assert
            Assert.True(!getDiscountId);
        }
    }
}
