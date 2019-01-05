using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentABag.Services.Mapping;
using RentABag.Web.Services.Contracts;
using RentABag.Web.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Controllers
{
    public class BagController : Controller
    {
        private const string homeControllerName = "Home";
        private const string administratorRole = "Administrator";
        private const string detailsName = "Details";
        private const string bagName = "Bag";

        private readonly IBagsService bagsService;
        private readonly IDesignersService designersService;
        private readonly ICategoriesService categoriesService;
        private readonly IShopsService shopsService;
        private readonly ICollectionsService collectionsService;

        public BagController(IBagsService bagsService, IDesignersService designersService, ICategoriesService categoriesService, IShopsService shopsService, ICollectionsService collectionsService)
        {
            this.bagsService = bagsService;
            this.designersService = designersService;
            this.categoriesService = categoriesService;
            this.shopsService = shopsService;
            this.collectionsService = collectionsService;
        }

        // GET: Bag
        [Authorize(Roles = administratorRole)]
        public ActionResult Index()
        {
            var allCategories = bagsService.GetAllBags();

            return View(allCategories);
        }

        // GET: Bag/Details/5
        public ActionResult Details(int id)
        {
            var bag = bagsService.GetBagById(id);

            if (bag == null)
            {
                return RedirectToAction(nameof(Index), homeControllerName);
            }

            var category = this.categoriesService.GetCategoryById(bag.CategoryId);
            var designer = this.designersService.GetDesignerById(bag.DesignerId);

            var bagViewModel = new BagViewModel()
            {
                Description = bag.Description,
                Category = category.Name,
                Designer = designer.Name,
                Id = bag.Id,
                Image = bag.Image,
                Name = bag.Name,
                Price = bag.Price
            };

            return View(bagViewModel);
        }

        // GET: Bag/Create
        [Authorize(Roles = administratorRole)]
        public ActionResult Create()
        {
            this.LoadViewData();

            return View();
        }

        // POST: Bag/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = administratorRole)]
        public async Task<ActionResult> Create(CreateBagViewModel vm)
        {
            if (ModelState.IsValid)
            {
                int bagId = await bagsService.CreateBagAsync(vm);

                return RedirectToAction(detailsName, bagName, new { id = bagId });
            }
            else
            {
                return View();
            }
        }

        // GET: Bag/Edit/5
        [Authorize(Roles = administratorRole)]
        public ActionResult Edit(int id)
        {
            this.LoadViewData();

            var bag = bagsService.GetBagById(id);

            if (bag == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var bagViewModel = new BagViewModel()
            {
                Description = bag.Description,
                Name = bag.Name,
                Id = bag.Id,
                DesignerId = bag.DesignerId,
                CategoryId = bag.CategoryId,
                Price = bag.Price
            };

            return View(bagViewModel);
        }

        private void LoadViewData()
        {
            ViewData["Categories"] = categoriesService.GetAllCategories()
                .To<IdAndNameViewModel>().Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
                .ToList();
            ViewData["Designers"] = designersService.GetAllDesigners()
                .To<IdAndNameViewModel>().Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
                .ToList();
            ViewData["Shops"] = shopsService.GetAllShops()
                .To<IdAndNameViewModel>().Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
                .ToList();
            ViewData["Collections"] = collectionsService.GetAllCollections()
                .To<IdAndNameViewModel>().Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
                .ToList();
        }

        // POST: Bag/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CreateBagViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var bag = bagsService.GetBagById(id);

                if (bag == null)
                {
                    return RedirectToAction(nameof(Index), homeControllerName);
                }

                int bagId = await bagsService.EditBagAsync(vm, bag);

                return RedirectToAction(detailsName, bagName, new { id = bagId });
            }
            else
            {
                LoadViewData();

                var bag = bagsService.GetBagById(id);

                if (bag == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                var bagViewModel = new BagViewModel()
                {
                    Description = bag.Description,
                    Name = bag.Name,
                    Id = bag.Id,
                    DesignerId = bag.DesignerId,
                    CategoryId = bag.CategoryId,
                    Price = bag.Price
                };

                return View(bagViewModel);
            }
        }

        // GET: Bag/Delete/5
        [Authorize(Roles = administratorRole)]
        public ActionResult Delete(int id)
        {
            try
            {
                var bag = this.bagsService.GetBagById(id);

                if (bag == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                this.bagsService.DeleteBagAsync(bag);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}