using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentABag.Models;
using RentABag.Services.Common;
using RentABag.ViewModels;
using RentABag.Helpers;
using RentABag.Web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Areas.Administrator.Controllers
{
    [Area(Constants.administratorRole)]
    [Authorize(Roles = Constants.administratorRole)]
    public class CollectionController : Controller
    {
        private readonly ICollectionsService collectionsService;

        public CollectionController(ICollectionsService collectionsService)
        {
            this.collectionsService = collectionsService;
        }

        // GET: Collection
        public ActionResult Index()
        {
            var allCollections = collectionsService.GetAllCollections().ToList();

            if (allCollections == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            return View(allCollections);
        }

        // GET: Collection/Details/5
        public ActionResult Details(int id)
        {
            var collection = collectionsService.GetCollectionById(id);

            if (collection == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            return View(collection);
        }

        // GET: Collection/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Collection/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateCollectionViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var collectionVm = Mapper.Map<CreateCollectionViewModel, CreateCollectionOtherViewModel>(vm);
                int collectionId = await collectionsService.CreateCollectionAsync(collectionVm);

                return RedirectToAction(Constants.detailsName, Constants.collectionName, new { id = collectionId });
            }
            else
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var collection = collectionsService.GetCollectionById(id);

            if (collection == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            var collectionViewModel = Mapper.Map<Collection, CollectionViewModel>(collection);

            return View(collectionViewModel);
        }

        // POST: Collection/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CreateCollectionViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var collection = collectionsService.GetCollectionById(id);

                if (collection == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }

                var collectionVm = Mapper.Map<CreateCollectionViewModel, CreateCollectionOtherViewModel>(vm);
                int collectionId = await collectionsService.EditCollectionAsync(collectionVm, collection);

                return RedirectToAction(Constants.detailsName, Constants.collectionName, new { id = collectionId });
            }
            else
            {
                var collection = collectionsService.GetCollectionById(id);

                if (collection == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }

                var collectionViewModel = Mapper.Map<Collection, CollectionViewModel>(collection);

                return View(collectionViewModel);
            }
        }

        // GET: Collection/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var collection = collectionsService.GetCollectionById(id);

                if (collection == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }

                collectionsService.DeleteCollectionAsync(collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }
        }
    }
}