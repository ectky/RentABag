using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentABag.Models;
using RentABag.Services.Mapping;
using RentABag.Web.Helpers;
using RentABag.Web.Models;
using RentABag.Web.Services.Contracts;
using RentABag.Web.ViewModels;

namespace RentABag.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICollectionsService collectionsService;
        private IBagsService bagsService;
        private IMessagesService messagesService;

        public HomeController(ICollectionsService collectionsService, IBagsService bagsService, IMessagesService messagesService)
        {
            this.collectionsService = collectionsService;
            this.bagsService = bagsService;
            this.messagesService = messagesService;
        }

        public IActionResult Index()
        {
            var collection = this.collectionsService.GetCurrentCollection();

            if (collection == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            var collectionViewModel = Mapper.Map<Collection ,CollectionViewModel>(collection);

            var dealOfTheWeek = this.bagsService.GetDealOfTheWeek();

            if (dealOfTheWeek == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            var bagViewModel = Mapper.Map<Bag, BagViewModel>(dealOfTheWeek);

            this.ViewData["DealOfTheWeek"] = bagViewModel;

            var bestSellers = this.bagsService.GetBestSellers(10);

            if (bestSellers == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            var queryable = bestSellers.AsQueryable();

            var bestSellersViewModels = queryable
                .To<BagViewModel>().ToArray();

            this.ViewData["BestSellers"] = bestSellersViewModels;
            this.ViewData["CurrentCollectionId"] = collection.Id;

            return View(collectionViewModel);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(CreateMessageViewModel vm)
        {
            if (ModelState.IsValid)
            {
                int messageId = await this.messagesService.CreateMessageAsync(vm);

                ViewData["Message"] = Constants.successfulMessage;

                return View();
            }
            else
            {
                return View();
            }
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
