using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentABag.Models;
using RentABag.Services.Common;
using RentABag.Services.Mapping;
using RentABag.ViewModels;
using RentABag.Web.Helpers;
using RentABag.Web.Models;
using RentABag.Web.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Areas.Administrator.Controllers
{
    [Area(Constants.administratorRole)]
    [Authorize(Roles = Constants.administratorRole)]
    public class BagController : Controller
    {
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
        public ActionResult Index()
        {
            var allCategories = bagsService.GetAllBags();

            return View(allCategories);
        }

        // GET: Bag/Details/5
        [AllowAnonymous]
        [Route(Constants.bagDetails)]
        public ActionResult Details(int id)
        {
            var bag = bagsService.GetBagById(id);

            if (bag == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            var bagViewModel = Mapper.Map<Bag, BagViewModel>(bag);
            ViewData["Bag"] = bagViewModel;
            return View();
        }

        // GET: Bag/Create
        public ActionResult Create()
        {
            LoadViewData();

            return View();
        }

        // POST: Bag/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBagViewModel vm, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var otherVm = new CreateBagOtherViewModel()
                {
                    CategoryId = vm.CategoryId,
                    CollectionId = vm.CollectionId,
                    DesignerId = vm.DesignerId,
                    Description = vm.Description,
                    DiscountPercent = vm.DiscountPercent,
                    Name = vm.Name,
                    Price = vm.Price
                };

                int bagId = await bagsService.CreateBagAsync(otherVm, file);

                return RedirectToAction(Constants.detailsName, Constants.bagName, new { id = bagId });
            }
            else
            {
                LoadViewData();

                return View();
            }
        }

        // GET: Bag/Edit/5
        public ActionResult Edit(int id)
        {
            LoadViewData();

            var bag = bagsService.GetBagById(id);

            if (bag == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            var bagViewModel = Mapper.Map<Bag, BagViewModel>(bag);

            bagViewModel.Image = null;

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
        public async Task<ActionResult> Edit(int id, CreateBagViewModel vm, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var bag = bagsService.GetBagById(id);

                if (bag == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }
                var bagVm = new CreateBagOtherViewModel()
                {
                    CategoryId = vm.CategoryId,
                    CollectionId = vm.CollectionId,
                    DesignerId = vm.DesignerId,
                    Description = vm.Description,
                    DiscountPercent = vm.DiscountPercent,
                    Name = vm.Name,
                    Price = vm.Price
                };

                int bagId = await bagsService.EditBagAsync(bagVm, bag, file);

                return RedirectToAction(Constants.detailsName, Constants.bagName, new { id = bagId });
            }
            else
            {
                LoadViewData();

                var bag = bagsService.GetBagById(id);

                if (bag == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }

                var bagViewModel = Mapper.Map<Bag, BagViewModel>(bag);

                return View(bagViewModel);
            }
        }

        // GET: Bag/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var bag = bagsService.GetBagById(id);

                if (bag == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }

                bagsService.DeleteBagAsync(bag);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }
        }
    }
}