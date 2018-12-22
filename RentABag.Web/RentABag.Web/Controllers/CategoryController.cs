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
    public class CategoryController : Controller
    {
        private const string homeControllerName = "Home";
        private const string administratorRole = "Administrator";
        private const string detailsName = "Details";
        private const string categoryName = "Category";

        private readonly ICategoriesService categoriesService;

        public CategoryController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        // GET: Category
        [Authorize(Roles = administratorRole)]
        public ActionResult Index()
        {
            var allCategories = this.categoriesService.GetAllCategories();

            return View(allCategories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var category = this.categoriesService.GetCategoryById(id);

            if (category == null)
            {
                return RedirectToAction(nameof(Index), homeControllerName);
            }

            return View(category);
        }

        // GET: Category/Create
        [Authorize(Roles = administratorRole)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = administratorRole)]
        public ActionResult Create(CreateCategoryViewModel vm)
        {
            try
            {
                int categoryId = this.categoriesService.CreateCategory(vm);

                return RedirectToAction(detailsName, categoryName, new { id = categoryId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        [Authorize(Roles = administratorRole)]
        public ActionResult Edit(int id)
        {
            var category = this.categoriesService.GetCategoryById(id);

            if (category == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var categoryViewModel = new CategoryViewModel()
            {
                Description = category.Description,
                Name = category.Name,
                Id = category.Id
            };

            return View(categoryViewModel);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateCategoryViewModel vm)
        {
            try
            {
                var category = this.categoriesService.GetCategoryById(id);

                if (category == null)
                {
                    return RedirectToAction(nameof(Index), homeControllerName);
                }

                int categoryId = this.categoriesService.EditCategory(vm, category);

                return RedirectToAction(detailsName, categoryName, new { id = categoryId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        [Authorize(Roles = administratorRole)]
        public ActionResult Delete(int id)
        {
            try
            {
                var category = this.categoriesService.GetCategoryById(id);

                if (category == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                this.categoriesService.DeleteCategory(category);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}