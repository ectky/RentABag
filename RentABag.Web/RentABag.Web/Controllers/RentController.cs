using Microsoft.AspNetCore.Mvc;
using RentABag.Services.Common;
using RentABag.Services.Mapping;
using RentABag.ViewModels;
using RentABag.Web.Helpers;
using System.Linq;

namespace RentABag.Web.Controllers
{
    public class RentController : Controller
    {
        private readonly IBagsService bagsService;
        private readonly ICategoriesService categoriesService;
        private readonly IDesignersService designersService;
        private readonly ICollectionsService collectionsService;

        public RentController(IBagsService bagsService, ICategoriesService categoriesService, IDesignersService designersService, ICollectionsService collectionsService)
        {
            this.bagsService = bagsService;
            this.categoriesService = categoriesService;
            this.designersService = designersService;
            this.collectionsService = collectionsService;
        }

        public IActionResult Index(int? id)
        {
            int page = id ?? 1;

            var pages = bagsService.GetPages();

            if (page > pages)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            var bags = bagsService.GetBagsForPage(page)
                .AsQueryable()
                .To<BagViewModel>();

            var categories = categoriesService.GetAllCategories();

            var designers = designersService.GetAllDesigners();

            var collection = collectionsService.GetCurrentCollection();

            if (collection == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            ViewData["CurrentCollectionId"] = collection.Id;
            ViewData["Pages"] = pages;
            ViewData["CurrentPage"] = page;
            ViewData["Categories"] = categories;
            ViewData["Designers"] = designers;
            return View(bags);
        }
    }
}