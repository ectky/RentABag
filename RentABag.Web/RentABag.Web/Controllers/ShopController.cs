using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentABag.Web.Services.Contracts;
using RentABag.Web.ViewModels;

namespace RentABag.Web.Controllers
{
    public class ShopController : Controller
    {
        private const string homeControllerName = "Home";
        private const string administratorRole = "Administrator";
        private const string detailsName = "Details";
        private const string shopName = "Shop";

        private readonly IShopsService shopsService;

        public ShopController(IShopsService shopsService)
        {
            this.shopsService = shopsService;
        }

        // GET: Shop
        [Authorize(Roles = administratorRole)]
        public ActionResult Index()
        {
            var allShops = this.shopsService.GetAllShops();

            return View(allShops);
        }

        // GET: Shop/Details/5
        public ActionResult Details(int id)
        {
            var shop = this.shopsService.GetShopById(id);

            if (shop == null)
            {
                return RedirectToAction(nameof(Index), homeControllerName);
            }

            return View(shop);
        }

        // GET: Shop/Create
        [Authorize(Roles = administratorRole)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shop/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateShopViewModel vm)
        {
            if (ModelState.IsValid)
            {
                int shopId = this.shopsService.CreateShop(vm);

                return RedirectToAction(detailsName, shopName, new { id = shopId });
            }
            else
            {
                return View();
            }
        }

        // GET: Shop/Edit/5
        [Authorize(Roles = administratorRole)]
        public ActionResult Edit(int id)
        {
            var shop = this.shopsService.GetShopById(id);

            if (shop == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var shopViewModel = new ShopViewModel()
            {
                Description = shop.Description,
                Name = shop.Name,
                Id = shop.Id,
                ActualAddress = shop.Address.ActualAddress,
                City = shop.Address.City,
                Country = shop.Address.Country,
                DiscountPercent = shop.DiscountPercent,
                PhoneNumber = shop.PhoneNumber,
                PostCode = shop.Address.PostCode
            };

            return View(shopViewModel);
        }

        // POST: Shop/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateShopViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var shop = this.shopsService.GetShopById(id);

                if (shop == null)
                {
                    return RedirectToAction(nameof(Index), homeControllerName);
                }

                int shopId = this.shopsService.EditShop(vm, shop);

                return RedirectToAction(detailsName, shopName, new { id = shopId });
            }
            else
            {
                var shop = this.shopsService.GetShopById(id);

                if (shop == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                var shopViewModel = new ShopViewModel()
                {
                    Description = shop.Description,
                    Name = shop.Name,
                    Id = shop.Id,
                    ActualAddress = shop.Address.ActualAddress,
                    City = shop.Address.City,
                    Country = shop.Address.Country,
                    DiscountPercent = shop.DiscountPercent,
                    PhoneNumber = shop.PhoneNumber,
                    PostCode = shop.Address.PostCode
                };

                return View(shopViewModel);
            }
        }

        // GET: Shop/Delete/5
        [Authorize(Roles = administratorRole)]
        public ActionResult Delete(int id)
        {
            try
            {
                var shop = this.shopsService.GetShopById(id);

                if (shop == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                this.shopsService.DeleteShop(shop);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}