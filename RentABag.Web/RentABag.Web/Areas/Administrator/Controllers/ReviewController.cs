using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentABag.Services.Common;
using RentABag.ViewModels;
using RentABag.Web.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Areas.Administrator.Controllers
{
    [Area(Constants.administratorRole)]
    [Authorize(Roles = Constants.administratorRole)]
    public class ReviewController : Controller
    {
        private readonly IReviewsService reviewsService;

        public ReviewController(IReviewsService reviewsService)
        {
            this.reviewsService = reviewsService;
        }

        // GET: Designer
        public ActionResult Index()
        {
            var allReviews = reviewsService.GetAllReviews().ToList();

            if (allReviews == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            return View(allReviews);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Create(int bagId, CreateReviewViewModel vm)
        {
            if (ModelState.IsValid)
            {
                int reviewId = await reviewsService.CreateReviewAsync(bagId, vm);
                ViewData["Message"] = Constants.successfulMessage;
                return RedirectToAction(Constants.detailsName, Constants.bagName, new { id = bagId });
            }
            else
            {
                return RedirectToAction(Constants.detailsName, Constants.bagName, new { id = bagId });
            }
        }

        // GET: Designer/Details/5
        public ActionResult Details(int id)
        {
            var review = reviewsService.GetReviewById(id);

            if (review == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            return View(review);
        }

        // GET: Designer/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var review = reviewsService.GetReviewById(id);

                if (review == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }

                reviewsService.DeleteReviewAsync(review);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }
        }
    }
}