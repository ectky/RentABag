using AutoMapper;
using RentABag.Services.Mapping;
using RentABag.ViewModels;
using System.Linq;
using Xunit;

namespace RentABag.Services.Tests
{
    [Collection("CollectionName")]
    public class CategoriesServiceTests
    {
        [Fact]
        public async void CreateCategoryAsync_ShouldCreateACategoryInDb()
        {
            // Arrange
            var dbContext = StaticMethods.GetDb();
            var categoriesService = new CategoriesService(dbContext);
            var categoryViewModel = new CreateCategoryViewModel()
            {
                Description = "Description",
                Name = "Name"
                
            };
            //Act

            var categoryId = await categoriesService.CreateCategoryAsync(categoryViewModel);
            var categoriesCount = dbContext.Categories.Count();

            var category = dbContext.Categories.Find(categoryId);

            //Assert
            Assert.True(categoriesCount == 1);
            Assert.True(category.Description == category.Description);
            Assert.True(category.Name == category.Name);
        }

        [Fact]
        public async void GetCategoryById_ShouldReturnCategory()
        {
            // Arrange
            var dbContext = StaticMethods.GetDb();
            var categoriesService = new CategoriesService(dbContext);
            var categoryViewModel = new CreateCategoryViewModel()
            {
                Description = "Description",
                Name = "Name"

            };
            //Act

            var categoryId = await categoriesService.CreateCategoryAsync(categoryViewModel);
            var category = dbContext.Categories.Find(categoryId);

            var getcategory = categoriesService.GetCategoryById(categoryId);

            //Assert
            Assert.True(category.Description == getcategory.Description);
            Assert.True(category.Name == getcategory.Name);
            Assert.True(category.Id == getcategory.Id);
        }

        [Fact]
        public async void ExistsCategoryWithWrongId_ShouldReturnFalse()
        {
            // Arrange
            var dbContext = StaticMethods.GetDb();
            var categoriesService = new CategoriesService(dbContext);
            var categoryViewModel = new CreateCategoryViewModel()
            {
                Description = "Description",
                Name = "Name"

            };
            var categoryId = await categoriesService.CreateCategoryAsync(categoryViewModel);
            var wrongId = 150;
            //Act
            
            var getcategoryId = categoriesService.ExistsCategoryWithId(wrongId);

            //Assert
            Assert.True(!getcategoryId);
        }

        [Fact]
        public async void ExistsCategoryWithId_ShouldReturnTrue()
        {
            // Arrange
            var dbContext = StaticMethods.GetDb();
            var categoriesService = new CategoriesService(dbContext);
            var categoryViewModel = new CreateCategoryViewModel()
            {
                Description = "Description",
                Name = "Name"

            };
            var categoryId = await categoriesService.CreateCategoryAsync(categoryViewModel);
            //Act

            var getcategoryId = categoriesService.ExistsCategoryWithId(categoryId);

            //Assert
            Assert.True(getcategoryId);
        }

        [Fact]
        public async void DeleteCategoryAsync_ShouldDeleteCategoryFromDb()
        {
            // Arrange
            var dbContext = StaticMethods.GetDb();
            var categoriesService = new CategoriesService(dbContext);
            var categoryViewModel = new CreateCategoryViewModel()
            {
                Description = "Description",
                Name = "Name"

            };
            var categoryId = await categoriesService.CreateCategoryAsync(categoryViewModel);
            //Act

            var category = categoriesService.GetCategoryById(categoryId);
            categoriesService.DeleteCategoryAsync(category);
            var categoriesCount = dbContext.Categories.Count();

            //Assert
            Assert.True(categoriesCount == 0);
        }

        [Fact]
        public async void EditCategoryAsync_ShouldChangeProperiesOfCategory()
        {
            var dbContext = StaticMethods.GetDb();
            var categoriesService = new CategoriesService(dbContext);
            var categoryViewModel1 = new CreateCategoryViewModel()
            {
                Description = "Description",
                Name = "Name"

            };
            var categoryId = await categoriesService.CreateCategoryAsync(categoryViewModel1);
            var category = categoriesService.GetCategoryById(categoryId);
            
            var categoryViewModel2 = new CreateCategoryViewModel()
            {
                Description = "Description",
                Name = "Name"

            };
            //Act

            var categoryId2 = await categoriesService.EditCategoryAsync(categoryViewModel2, category);
            var category2 = categoriesService.GetCategoryById(categoryId2);

            //Assert
            Assert.True(category2.Description == category.Description);
            Assert.True(category2.Name == category.Name);
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
            var categoriesService = new CategoriesService(dbContext);
            
            int count = 6;

            for (int i = 0; i < count; i++)
            {
                var categoryViewModel = new CreateCategoryViewModel()
                {
                    Description = "Description",
                    Name = "Name"

                };
                var categoryId = await categoriesService.CreateCategoryAsync(categoryViewModel);
            }
            //Act

            var allCategories = categoriesService.GetAllCategories();
            var categoriesCount = dbContext.Categories.Count();

            //Assert
            Assert.True(count == categoriesCount && count == allCategories.Count());
        }
    }
}
