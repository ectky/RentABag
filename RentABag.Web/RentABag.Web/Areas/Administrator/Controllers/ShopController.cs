using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentABag.Models;
using RentABag.Services.Common;
using RentABag.ViewModels;
using RentABag.Web.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Areas.Administrator.Controllers
{
    [Area(Constants.administratorRole)]
    [Authorize(Roles = Constants.administratorRole)]
    public class ShopController : Controller
    {
        private readonly IShopsService shopsService;

        public ShopController(IShopsService shopsService)
        {
            this.shopsService = shopsService;
        }

        // GET: Shop
        public ActionResult Index()
        {
            var allShops = shopsService.GetAllShops().ToList();

            if (allShops == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            return View(allShops);
        }

        // GET: Shop/Details/5
        [Route(Constants.shopDetails)]
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var shop = shopsService.GetShopById(id);

            if (shop == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            return View(shop);
        }

        // GET: Shop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shop/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Create(CreateShopViewModel vm)
        {
            if (ModelState.IsValid)
            {
                int shopId = await shopsService.CreateShopAsync(vm);

                return RedirectToAction(Constants.detailsName, Constants.shopName, new { id = shopId });
            }
            else
            {
                return View();
            }
        }

        // GET: Shop/Edit/5
        public ActionResult Edit(int id)
        {
            var shop = shopsService.GetShopById(id);

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
                var shop = shopsService.GetShopById(id);

                if (shop == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }

                int shopId = await shopsService.EditShopAsync(vm, shop);

                return RedirectToAction(Constants.detailsName, Constants.shopName, new { id = shopId });
            }
            else
            {
                var shop = shopsService.GetShopById(id);

                if (shop == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                var shopViewModel = Mapper.Map<Shop, ShopViewModel>(shop);

                return View(shopViewModel);
            }
        }

        // GET: Shop/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var shop = shopsService.GetShopById(id);

                if (shop == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }

                shopsService.DeleteShopAsync(shop);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }
        }
    }
}