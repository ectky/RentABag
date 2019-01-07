using RentABag.Models;
using RentABag.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Services.Contracts
{
    public interface IReviewsService
    {
        Task<int> CreateReviewAsync(int bag, CreateReviewViewModel vm);
        Review GetReviewById(int id);
        void DeleteReviewAsync(Review review);
        IQueryable<ReviewViewModel> GetAllReviews();
    }
}
