using AutoMapper;
using RentABag.Services.Mapping;
using RentABag.ViewModels;
using System.Linq;
using Xunit;

namespace RentABag.Services.Tests
{
    [Collection("CollectionName")]
    public class MessagesServicesTests
    {
        [Fact]
        public async void CreateMessageAsync_ShouldCreateAMessageInDb()
        {
            // Arrange
            Mapper.Reset();
            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var messagesService = new MessagesService(dbContext);
            var messageViewModel = new CreateMessageViewModel()
            {
                Name = "Name",
                Email = "Email",
                Content = "Content"
            };
            //Act

            var messageId = await messagesService.CreateMessageAsync(messageViewModel);
            var reviewsCount = dbContext.Messages.Count();

            var review = dbContext.Messages.Find(messageId);

            //Assert
            Assert.True(reviewsCount == 1);
            Assert.True(messageViewModel.Content == review.Content);
            Assert.True(messageViewModel.Name == review.Name);
            Assert.True(messageViewModel.Email == review.Email);
        }

        [Fact]
        public async void DeleteMessage_ShouldDeleteMessageFromDb()
        {
            // Arrange
            Mapper.Reset();
            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var messagesService = new MessagesService(dbContext);
            var messageViewModel = new CreateMessageViewModel()
            {
                Name = "Name",
                Email = "Email",
                Content = "Content"
            };
            var messageId = await messagesService.CreateMessageAsync(messageViewModel);
            var message = messagesService.GetMessageById(messageId);
            //Act

            messagesService.DeleteMessageAsync(message);
            var reviewsCount = dbContext.Messages.Count();

            //Assert
            Assert.True(reviewsCount == 0);
        }

        [Fact]
        public async void GetAllMessages_ShouldReturnAllMessagesFromDb()
        {
            // Arrange
            Mapper.Reset();
            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var messagesService = new MessagesService(dbContext);

            var count = 6;
            for (int i = 0; i < count; i++)
            {
                var messageViewModel = new CreateMessageViewModel()
                {
                    Name = "Name",
                    Email = "Email",
                    Content = "Content"
                };
                var messageId = await messagesService.CreateMessageAsync(messageViewModel);
            }

            //Act

            var allreviews = messagesService.GetAllMessages();
            var shopsCount = dbContext.Messages.Count();

            //Assert
            Assert.True(count == shopsCount && count == allreviews.Count());
        }
    }
}
