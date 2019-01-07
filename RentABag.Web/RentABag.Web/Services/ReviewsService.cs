using AutoMapper;
using RentABag.Models;
using RentABag.Services.Mapping;
using RentABag.Web.Data;
using RentABag.Web.Services.Contracts;
using RentABag.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Services
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

            await this.context.Reviews.AddAsync(review);
            await this.context.SaveChangesAsync();

            int reviewId = review.Id;

            return reviewId;
        }

        public async void DeleteReviewAsync(Review review)
        {
            this.context.Remove(review);
            await this.context.SaveChangesAsync();
        }

        public IQueryable<ReviewViewModel> GetAllReviews()
        {
            var reviews = this.context.Reviews
                .To<ReviewViewModel>();

            return reviews;
        }

        public Review GetReviewById(int id)
        {
            var review = this.context.Reviews.FirstOrDefault(d => d.Id == id);

            return review;
        }
    }
}
