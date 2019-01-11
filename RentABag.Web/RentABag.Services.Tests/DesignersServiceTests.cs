using AutoMapper;
using RentABag.Services.Mapping;
using RentABag.ViewModels;
using System.Linq;
using Xunit;

namespace RentABag.Services.Tests
{
    [Collection("CollectionName")]
    public class DesignersServiceTests
    {
        [Fact]
        public async void CreateDesignerAsync_ShouldCreateADesignerInDb()
        {
            // Arrange
            Mapper.Reset();

            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var designersService = new DesignersService(dbContext);
            var designerViewModel = new CreateDesignerViewModel()
            {
                Description = "Description",
                Name = "Name"

            };
            //Act

            var designerId = await designersService.CreateDesignerAsync(designerViewModel, null);
            var designersCount = dbContext.Designers.Count();

            var designer = dbContext.Designers.Find(designerId);

            //Assert
            Assert.True(designersCount == 1);
            Assert.True(designer.Description == designer.Description);
            Assert.True(designer.Name == designer.Name);
        }

        [Fact]
        public async void GetDesignerById_ShouldReturnDesigner()
        {
            // Arrange
            Mapper.Reset();
            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var designersService = new DesignersService(dbContext);
            var designerViewModel = new CreateDesignerViewModel()
            {
                Description = "Description",
                Name = "Name"

            };
            //Act

            var designerId = await designersService.CreateDesignerAsync(designerViewModel, null);
            var designer = dbContext.Designers.Find(designerId);

            var getdesigner = designersService.GetDesignerById(designerId);

            //Assert
            Assert.True(designer.Description == getdesigner.Description);
            Assert.True(designer.Name == getdesigner.Name);
            Assert.True(designer.Id == getdesigner.Id);
        }

        [Fact]
        public async void DeleteDesignerAsync_ShouldDeleteDesignerFromDb()
        {
            // Arrange
            Mapper.Reset();
            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var designersService = new DesignersService(dbContext);
            var designerViewModel = new CreateDesignerViewModel()
            {
                Description = "Description",
                Name = "Name"

            };
            var designerId = await designersService.CreateDesignerAsync(designerViewModel, null);
            //Act

            var designer = designersService.GetDesignerById(designerId);
            designersService.DeleteDesignerAsync(designer);
            var designersCount = dbContext.Designers.Count();

            //Assert
            Assert.True(designersCount == 0);
        }

        [Fact]
        public async void EditDesignerAsync_ShouldChangeProperiesOfDesigner()
        {
            Mapper.Reset();
            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var designersService = new DesignersService(dbContext);
            var designerViewModel1 = new CreateDesignerViewModel()
            {
                Description = "Description",
                Name = "Name"

            };
            var designerId = await designersService.CreateDesignerAsync(designerViewModel1, null);
            var designer = designersService.GetDesignerById(designerId);

            var designerViewModel2 = new CreateDesignerViewModel()
            {
                Description = "Description",
                Name = "Name"

            };
            //Act

            var designerId2 = await designersService.EditDesignerAsync(designerViewModel2, designer, null);
            var designer2 = designersService.GetDesignerById(designerId2);

            //Assert
            Assert.True(designer2.Description == designer.Description);
            Assert.True(designer2.Name == designer.Name);
        }

        [Fact]
        public async void GetAllCategories_ShouldReturnAllCategoriesFromDb()
        {
            // Arrange
            Mapper.Reset();

            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var designersService = new DesignersService(dbContext);

            int count = 6;

            for (int i = 0; i < count; i++)
            {
                var designerViewModel = new CreateDesignerViewModel()
                {
                    Description = "Description",
                    Name = "Name"

                };
                var designerId = await designersService.CreateDesignerAsync(designerViewModel, null);
            }
            //Act

            var alldesigners = designersService.GetAllDesigners();
            var designersCount = dbContext.Designers.Count();

            //Assert
            Assert.True(count == designersCount && count == alldesigners.Count());
        }
    }
}
