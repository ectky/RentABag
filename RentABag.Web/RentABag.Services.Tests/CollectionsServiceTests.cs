using AutoMapper;
using RentABag.Services.Mapping;
using RentABag.ViewModels;
using System;
using System.Linq;
using Xunit;

namespace RentABag.Services.Tests
{
    [Collection("CollectionName")]
    public class CollectionsServiceTests
    {
        [Fact]
        public async void CreateCollectionAsync_ShouldCreateACollectionInDb()
        {
            // Arrange
            Mapper.Reset();

            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var collectionsService = new CollectionsService(dbContext);
            var collectionViewModel = new CreateCollectionOtherViewModel()
            {
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                Name = "Name"

            };
            //Act

            var collectionId = await collectionsService.CreateCollectionAsync(collectionViewModel);
            var collectionsCount = dbContext.Collections.Count();

            var collection = dbContext.Collections.Find(collectionId);

            //Assert
            Assert.True(collectionsCount == 1);
            Assert.True(collection.EndDate == collection.EndDate);
            Assert.True(collection.StartDate == collection.StartDate);
            Assert.True(collection.Name == collection.Name);
        }

        [Fact]
        public async void GetCollectionById_ShouldReturnCollection()
        {
            // Arrange
            Mapper.Reset();
            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var collectionsService = new CollectionsService(dbContext);
            var collectionViewModel = new CreateCollectionOtherViewModel()
            {
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                Name = "Name"

            };
            //Act

            var collectionId = await collectionsService.CreateCollectionAsync(collectionViewModel);
            var collection = dbContext.Collections.Find(collectionId);

            var getCollection = collectionsService.GetCollectionById(collectionId);

            //Assert
            Assert.True(collection.EndDate == getCollection.EndDate);
            Assert.True(collection.StartDate == getCollection.StartDate);
            Assert.True(collection.Name == getCollection.Name);
            Assert.True(collection.Id == getCollection.Id);
        }

        [Fact]
        public async void DeleteCollectionAsync_ShouldDeleteCollectionFromDb()
        {
            // Arrange
            Mapper.Reset();
            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var collectionsService = new CollectionsService(dbContext);
            var collectionViewModel = new CreateCollectionOtherViewModel()
            {
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                Name = "Name"

            };
            var collectionId = await collectionsService.CreateCollectionAsync(collectionViewModel);
            //Act

            var collection = collectionsService.GetCollectionById(collectionId);
            collectionsService.DeleteCollectionAsync(collection);
            var collectionsCount = dbContext.Collections.Count();

            //Assert
            Assert.True(collectionsCount == 0);
        }

        [Fact]
        public async void EditCollectionAsync_ShouldChangeProperiesOfCollection()
        {
            Mapper.Reset();
            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var collectionsService = new CollectionsService(dbContext);
            var collectionViewModel = new CreateCollectionOtherViewModel()
            {
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                Name = "Name"

            };
            var collectionId = await collectionsService.CreateCollectionAsync(collectionViewModel);
            var collection = collectionsService.GetCollectionById(collectionId);

            var collectionViewModel2 = new CreateCollectionOtherViewModel()
            {
                EndDate = DateTime.Now.AddDays(1),
                StartDate = DateTime.Now.AddDays(1),
                Name = "Name2"
            };
            //Act

            var collectionId2 = await collectionsService.EditCollectionAsync(collectionViewModel2, collection);
            var collection2 = collectionsService.GetCollectionById(collectionId2);

            //Assert
            Assert.True(collection2.StartDate == collection.StartDate);
            Assert.True(collection2.EndDate == collection.EndDate);
            Assert.True(collection2.Name == collection.Name);
        }

        [Fact]
        public async void GetAllCollections_ShouldReturnAllCollectionsFromDb()
        {
            // Arrange
            Mapper.Reset();

            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var collectionsService = new CollectionsService(dbContext);

            int count = 6;

            for (int i = 0; i < count; i++)
            {
                var collectionViewModel = new CreateCollectionOtherViewModel()
                {
                    EndDate = DateTime.Now,
                    StartDate = DateTime.Now,
                    Name = "Name"

                };
                var collectionId = await collectionsService.CreateCollectionAsync(collectionViewModel);
            }
            //Act

            var allCollections = collectionsService.GetAllCollections();
            var collectionsCount = dbContext.Collections.Count();

            //Assert
            Assert.True(count == collectionsCount && count == allCollections.Count());
        }
    }
}
