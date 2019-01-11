using AutoMapper;
using RentABag.Services.Mapping;
using RentABag.ViewModels;
using System.Linq;
using Xunit;

namespace RentABag.Services.Tests
{
    [Collection("CollectionName")]
    public class ReviewsServicesTests
    {
        [Fact]
        public async void CreateReviewAsync_ShouldCreateAReviewInDb()
        {
            // Arrange
            Mapper.Reset();
            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var bagsService = new BagsService(dbContext);
            var reviewsService = new ReviewsService(dbContext);
            var reviewViewModel = new CreateReviewViewModel()
            {
                Name = "Name",
                Comment = "Comment",
                Email = "Email",
                Rating = 5
            };

            var bagViewModel = new CreateBagOtherViewModel()
            {
                Description = "Description",
                DiscountPercent = 0,
                Name = "Name",
                Price = 200
            };
            var bagId = await bagsService.CreateBagAsync(bagViewModel, null);
            //Act

            var reviewId = await reviewsService.CreateReviewAsync(bagId, reviewViewModel);
            var reviewsCount = dbContext.Reviews.Count();

            var review = dbContext.Reviews.Find(reviewId);

            //Assert
            Assert.True(reviewsCount == 1);
            Assert.True(reviewViewModel.Comment == review.Comment);
            Assert.True(reviewViewModel.Name == review.Name);
            Assert.True(reviewViewModel.Email == review.Email);
            Assert.True(reviewViewModel.Rating == review.Rating);
            Assert.True(bagId == review.BagId);
        }

        [Fact]
        public async void DeleteReview_ShouldDeleteReviewFromDb()
        {
            // Arrange
            Mapper.Reset();
            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var bagsService = new BagsService(dbContext);
            var reviewsService = new ReviewsService(dbContext);
            var reviewViewModel = new CreateReviewViewModel()
            {
                Name = "Name",
                Comment = "Comment",
                Email = "Email",
                Rating = 5
            };

            var bagViewModel = new CreateBagOtherViewModel()
            {
                Description = "Description",
                DiscountPercent = 0,
                Name = "Name",
                Price = 200
            };
            var bagId = await bagsService.CreateBagAsync(bagViewModel, null);
            var reviewId = await reviewsService.CreateReviewAsync(bagId, reviewViewModel);
            var review = reviewsService.GetReviewById(reviewId);
            //Act

            reviewsService.DeleteReviewAsync(review);
            var reviewsCount = dbContext.Reviews.Count();

            //Assert
            Assert.True(reviewsCount == 0);
        }

        [Fact]
        public async void GetAllReviews_ShouldReturnAllReviewsFromDb()
        {
            // Arrange
            Mapper.Reset();
            AutoMapperConfig.RegisterMappings(
                typeof(CreateDesignerViewModel).Assembly
                );
            var dbContext = StaticMethods.GetDb();
            var bagsService = new BagsService(dbContext);
            var reviewsService = new ReviewsService(dbContext);

            var count = 6;
            for (int i = 0; i < count; i++)
            {
                var reviewViewModel = new CreateReviewViewModel()
                {
                    Name = "Name",
                    Comment = "Comment",
                    Email = "Email",
                    Rating = 5
                };

                var bagViewModel = new CreateBagOtherViewModel()
                {
                    Description = "Description",
                    DiscountPercent = 0,
                    Name = "Name",
                    Price = 200
                };
                var bagId = await bagsService.CreateBagAsync(bagViewModel, null);
                var reviewId = await reviewsService.CreateReviewAsync(bagId, reviewViewModel);
            }

            //Act

            var allreviews = reviewsService.GetAllReviews();
            var shopsCount = dbContext.Reviews.Count();

            //Assert
            Assert.True(count == shopsCount && count == allreviews.Count());
        }
    }
}
