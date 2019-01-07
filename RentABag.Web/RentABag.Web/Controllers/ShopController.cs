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
    public class ShopController : Controller
    {
        private readonly IShopsService shopsService;

        public ShopController(IShopsService shopsService)
        {
            this.shopsService = shopsService;
        }

        // GET: Shop
        [Authorize(Roles = Constants.administratorRole)]
        public ActionResult Index()
        {
            var allShops = this.shopsService.GetAllShops().ToList();

            if (allShops == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            return View(allShops);
        }

        // GET: Shop/Details/5
        public ActionResult Details(int id)
        {
            var shop = this.shopsService.GetShopById(id);

            if (shop == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            return View(shop);
        }

        // GET: Shop/Create
        [Authorize(Roles = Constants.administratorRole)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shop/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateShopViewModel vm)
        {
            if (ModelState.IsValid)
            {
                int shopId = await this.shopsService.CreateShopAsync(vm);

                return RedirectToAction(Constants.detailsName, Constants.shopName, new { id = shopId });
            }
            else
            {
                return View();
            }
        }

        // GET: Shop/Edit/5
        [Authorize(Roles = Constants.administratorRole)]
        public ActionResult Edit(int id)
        {
            var shop = this.shopsService.GetShopById(id);

            if (shop == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var shopViewModel = Mapper.Map<Shop, ShopViewModel>(shop);

            return View(shopViewModel);
        }

        // POST: Shop/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CreateShopViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var shop = this.shopsService.GetShopById(id);

                if (shop == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }

                int shopId = await this.shopsService.EditShopAsync(vm, shop);

                return RedirectToAction(Constants.detailsName, Constants.shopName, new { id = shopId });
            }
            else
            {
                var shop = this.shopsService.GetShopById(id);

                if (shop == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                var shopViewModel = Mapper.Map<Shop, ShopViewModel>(shop);

                return View(shopViewModel);
            }
        }

        // GET: Shop/Delete/5
        [Authorize(Roles = Constants.administratorRole)]
        public ActionResult Delete(int id)
        {
            try
            {
                var shop = this.shopsService.GetShopById(id);

                if (shop == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }

                this.shopsService.DeleteShopAsync(shop);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }
        }
    }
}