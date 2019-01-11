using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentABag.Helpers;
using RentABag.Models;
using RentABag.Services.Common;
using RentABag.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Areas.Administrator.Controllers
{
    [Area(Constants.administratorRole)]
    [Authorize(Roles = Constants.administratorRole)]
    public class DiscountCodeController : Controller
    {
        private readonly IDiscountCodesService discountCodesService;

        public DiscountCodeController(IDiscountCodesService categoriesService)
        {
            this.discountCodesService = categoriesService;
        }

        // GET: Category
        public ActionResult Index()
        {
            var allCategories = discountCodesService.GetAllDiscountCodes();

            if (allCategories == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            return View(allCategories);
        }

        // GET: Category/Details/5
        [Route(Constants.categoryDetails)]
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var category = discountCodesService.GetDiscountCodeById(id);

            if (category == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateDiscountCodeViewModel vm)
        {
            if (ModelState.IsValid)
            {
                int categoryId = await discountCodesService.CreateDiscountCodeAsync(vm);

                return RedirectToAction(Constants.detailsName, Constants.categoryName, new { id = categoryId });
            }
            else
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var discountCode = discountCodesService.GetDiscountCodeById(id);

            if (discountCode == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            return View(discountCode);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CreateDiscountCodeViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var category = discountCodesService.GetDiscountCodeById(id);

                if (category == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }

                int categoryId = await discountCodesService.EditDiscountCodeAsync(vm, category);

                return RedirectToAction(Constants.detailsName, Constants.categoryName, new { id = categoryId });
            }
            else
            {
                var discountCode = discountCodesService.GetDiscountCodeById(id);

                if (discountCode == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }

                return View(discountCode);
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var category = discountCodesService.GetDiscountCodeById(id);

                if (category == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }

                discountCodesService.DeleteDiscountCodeAsync(category);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }
        }
    }
}