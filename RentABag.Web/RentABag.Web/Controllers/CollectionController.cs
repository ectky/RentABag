using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentABag.Models;
using RentABag.Services.Mapping;
using RentABag.Web.Helpers;
using RentABag.Web.Services.Contracts;
using RentABag.Web.ViewModels;

namespace RentABag.Web.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ICollectionsService collectionsService;

        public CollectionController(ICollectionsService collectionsService)
        {
            this.collectionsService = collectionsService;
        }

        // GET: Collection
        [Authorize(Roles = Constants.administratorRole)]
        public ActionResult Index()
        {
            var allCollections = this.collectionsService.GetAllCollections().ToList();

            if (allCollections == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            return View(allCollections);
        }

        // GET: Collection/Details/5
        public ActionResult Details(int id)
        {
            var collection = this.collectionsService.GetCollectionById(id);

            if (collection == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            return View(collection);
        }

        // GET: Collection/Create
        [Authorize(Roles = Constants.administratorRole)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Collection/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Constants.administratorRole)]
        public async Task<ActionResult> Create(CreateCollectionViewModel vm)
        {
            if (ModelState.IsValid)
            {
                int collectionId = await this.collectionsService.CreateCollectionAsync(vm);

                return RedirectToAction(Constants.detailsName, Constants.collectionName, new { id = collectionId });
            }
            else
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        [Authorize(Roles = Constants.administratorRole)]
        public ActionResult Edit(int id)
        {
            var collection = this.collectionsService.GetCollectionById(id);

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
                var collection = this.collectionsService.GetCollectionById(id);

                if (collection == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }

                int collectionId = await this.collectionsService.EditCollectionAsync(vm, collection);

                return RedirectToAction(Constants.detailsName, Constants.collectionName, new { id = collectionId });
            }
            else
            {
                var collection = this.collectionsService.GetCollectionById(id);

                if (collection == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }

                var collectionViewModel = Mapper.Map<Collection, CollectionViewModel>(collection);

                return View(collectionViewModel);
            }
        }

        // GET: Collection/Delete/5
        [Authorize(Roles = Constants.administratorRole)]
        public ActionResult Delete(int id)
        {
            try
            {
                var collection = this.collectionsService.GetCollectionById(id);

                if (collection == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }

                this.collectionsService.DeleteCollectionAsync(collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }
        }
    }
}