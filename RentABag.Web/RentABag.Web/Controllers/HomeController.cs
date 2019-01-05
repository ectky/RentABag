using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentABag.Models;
using RentABag.Services.Mapping;
using RentABag.Web.Models;
using RentABag.Web.Services.Contracts;
using RentABag.Web.ViewModels;

namespace RentABag.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICollectionsService collectionsService;
        private IBagsService bagsService;

        public HomeController(ICollectionsService collectionsService, IBagsService bagsService)
        {
            this.collectionsService = collectionsService;
            this.bagsService = bagsService;
        }

        public IActionResult Index()
        {
            var collection = this.collectionsService.GetCurrentCollection();

            if (collection == null)
            {
                return new NotFoundResult();
            }

            var collectionViewModel = Mapper.Map<Collection ,CollectionViewModel>(collection);

            var dealOfTheWeek = this.bagsService.GetDealOfTheWeek();

            if (dealOfTheWeek == null)
            {
                return new NotFoundResult();
            }

            var bagViewModel = Mapper.Map<Bag, BagViewModel>(dealOfTheWeek);

            this.ViewData["DealOfTheWeek"] = bagViewModel;

            var bestSellers = this.bagsService.GetBestSellers(10);

            if (bestSellers == null)
            {
                return new NotFoundResult();
            }

            var queryable = bestSellers.AsQueryable();

            var bestSellersViewModels = queryable
                .To<BagViewModel>().ToArray();

            this.ViewData["BestSellers"] = bestSellersViewModels;
            this.ViewData["CurrentCollectionId"] = collection.Id;

            return View(collectionViewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
