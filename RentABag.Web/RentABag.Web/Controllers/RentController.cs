using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentABag.Services.Mapping;
using RentABag.Web.Helpers;
using RentABag.Web.Services.Contracts;
using RentABag.Web.ViewModels;

namespace RentABag.Web.Controllers
{
    public class RentController : Controller
    {
        private readonly IBagsService bagsService;

        public RentController(IBagsService bagsService)
        {
            this.bagsService = bagsService;
        }

        public IActionResult Index(int? id)
        {
            int page = id?? 1;

            var pages = this.bagsService.GetPages();

            if (page > pages)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            var bags = this.bagsService.GetBagsForPage(page)
                .AsQueryable()
                .To<BagViewModel>();

            this.ViewData["Pages"] = pages;
            this.ViewData["CurrentPage"] = page;
            return View(bags);
        }
    }
}