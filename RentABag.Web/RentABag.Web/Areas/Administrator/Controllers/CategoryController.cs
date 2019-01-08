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
    public class CategoryController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoryController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        // GET: Category
        public ActionResult Index()
        {
            var allCategories = categoriesService.GetAllCategories().ToList();

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
            var category = categoriesService.GetCategoryById(id);

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
        public async Task<ActionResult> Create(CreateCategoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                int categoryId = await categoriesService.CreateCategoryAsync(vm);

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
            var category = categoriesService.GetCategoryById(id);

            if (category == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            var categoryViewModel = Mapper.Map<Category, CategoryViewModel>(category);

            return View(categoryViewModel);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CreateCategoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var category = categoriesService.GetCategoryById(id);

                if (category == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }

                int categoryId = await categoriesService.EditCategoryAsync(vm, category);

                return RedirectToAction(Constants.detailsName, Constants.categoryName, new { id = categoryId });
            }
            else
            {
                var category = categoriesService.GetCategoryById(id);

                if (category == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }

                var categoryViewModel = Mapper.Map<Category, CategoryViewModel>(category);

                return View(categoryViewModel);
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var category = categoriesService.GetCategoryById(id);

                if (category == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }

                categoriesService.DeleteCategoryAsync(category);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }
        }
    }
}