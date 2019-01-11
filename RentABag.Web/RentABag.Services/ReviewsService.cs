using AutoMapper;
using RentABag.Models;
using RentABag.Services.Common;
using RentABag.Services.Mapping;
using RentABag.ViewModels;
using RentABag.Web.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly RentABagDbContext context;

        public ReviewsService(RentABagDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateReviewAsync(int bagId, CreateReviewViewModel vm)
        {
            var review = Mapper.Map<CreateReviewViewModel, Review>(vm);
            review.ReviewedOn = DateTime.Now;
            review.BagId = bagId;

            await context.Reviews.AddAsync(review);
            await context.SaveChangesAsync();

            int reviewId = review.Id;

            return reviewId;
        }

        public async void DeleteReviewAsync(Review review)
        {
            context.Remove(review);
            await context.SaveChangesAsync();
        }

        public IQueryable<ReviewViewModel> GetAllReviews()
        {
            var reviews = context.Reviews
                .To<ReviewViewModel>();

            return reviews;
        }

        public Review GetReviewById(int id)
        {
            var review = context.Reviews.FirstOrDefault(d => d.Id == id);

            return review;
        }
    }
}
