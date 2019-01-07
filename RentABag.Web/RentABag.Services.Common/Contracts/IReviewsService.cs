using RentABag.Models;
using RentABag.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Services.Common
{
    public interface IReviewsService
    {
        Task<int> CreateReviewAsync(int bag, CreateReviewViewModel vm);
        Review GetReviewById(int id);
        void DeleteReviewAsync(Review review);
        IQueryable<ReviewViewModel> GetAllReviews();
    }
}
