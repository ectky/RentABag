using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentABag.Models;
using RentABag.Web.Helpers;
using RentABag.Web.Services.Contracts;
using RentABag.Web.ViewModels;

namespace RentABag.Web.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewsService reviewsService;

        public ReviewController(IReviewsService reviewsService)
        {
            this.reviewsService = reviewsService;
        }

        // GET: Designer
        [Authorize(Roles = Constants.administratorRole)]
        public ActionResult Index()
        {
            var allReviews = this.reviewsService.GetAllReviews().ToList();

            if (allReviews == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            return View(allReviews);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int bagId, CreateReviewViewModel vm)
        {
            if (ModelState.IsValid)
            {
                int reviewId = await this.reviewsService.CreateReviewAsync(bagId, vm);
                ViewData["Message"] = Constants.successfulMessage;
                return RedirectToAction(Constants.detailsName, Constants.bagName, new { id = bagId });
            }
            else
            {
                return RedirectToAction(Constants.detailsName, Constants.bagName, new { id = bagId });
            }
        }

        // GET: Designer/Details/5
        [Authorize(Roles = Constants.administratorRole)]
        public ActionResult Details(int id)
        {
            var review = this.reviewsService.GetReviewById(id);

            if (review == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            return View(review);
        }

        // GET: Designer/Delete/5
        [Authorize(Roles = Constants.administratorRole)]
        public ActionResult Delete(int id)
        {
            try
            {
                var review = this.reviewsService.GetReviewById(id);

                if (review == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }

                this.reviewsService.DeleteReviewAsync(review);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }
        }
    }
}