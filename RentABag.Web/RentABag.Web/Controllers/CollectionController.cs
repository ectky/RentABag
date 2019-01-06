using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentABag.Services.Mapping;
using RentABag.Web.Services.Contracts;
using RentABag.Web.ViewModels;

namespace RentABag.Web.Controllers
{
    public class CollectionController : Controller
    {
        private const string homeControllerName = "Home";
        private const string administratorRole = "Administrator";
        private const string detailsName = "Details";
        private const string collectionName = "Collection";

        private readonly ICollectionsService collectionsService;

        public CollectionController(ICollectionsService collectionsService)
        {
            this.collectionsService = collectionsService;
        }

        // GET: Collection
        [Authorize(Roles = administratorRole)]
        public ActionResult Index()
        {
            var allCollections = this.collectionsService.GetAllCollections().ToList();

            return View(allCollections);
        }

        // GET: Collection/Details/5
        public ActionResult Details(int id)
        {
            var collection = this.collectionsService.GetCollectionById(id);

            if (collection == null)
            {
                return RedirectToAction(nameof(Index), homeControllerName);
            }

            return View(collection);
        }

        // GET: Collection/Create
        [Authorize(Roles = administratorRole)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Collection/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = administratorRole)]
        public async Task<ActionResult> Create(CreateCollectionViewModel vm)
        {
            if (ModelState.IsValid)
            {
                int collectionId = await this.collectionsService.CreateCollectionAsync(vm);

                return RedirectToAction(detailsName, collectionName, new { id = collectionId });
            }
            else
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        [Authorize(Roles = administratorRole)]
        public ActionResult Edit(int id)
        {
            var collection = this.collectionsService.GetCollectionById(id);

            if (collection == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var collectionViewModel = new CollectionViewModel()
            {
                StartDate = collection.StartDate,
                EndDate = collection.EndDate,
                Name = collection.Name,
                Id = collection.Id,
                Bags = collection.Bags.AsQueryable()
                .To<BagViewModel>().ToArray()
            };

            return View(collectionViewModel);
        }

        // POST: Collection/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CreateCollectionViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var collection = this.collectionsService.GetCollectionById(id);

                if (collection == null)
                {
                    return RedirectToAction(nameof(Index), homeControllerName);
                }

                int collectionId = await this.collectionsService.EditCollectionAsync(vm, collection);

                return RedirectToAction(detailsName, collectionName, new { id = collectionId });
            }
            else
            {
                var collection = this.collectionsService.GetCollectionById(id);

                if (collection == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                var collectionViewModel = new CollectionViewModel()
                {
                    StartDate = collection.StartDate,
                    EndDate = collection.EndDate,
                    Name = collection.Name,
                    Id = collection.Id,
                    Bags = collection.Bags.AsQueryable()
                    .To<BagViewModel>().ToArray()
                };

                return View(collectionViewModel);
            }
        }

        // GET: Collection/Delete/5
        [Authorize(Roles = administratorRole)]
        public ActionResult Delete(int id)
        {
            try
            {
                var collection = this.collectionsService.GetCollectionById(id);

                if (collection == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                this.collectionsService.DeleteCollectionAsync(collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}