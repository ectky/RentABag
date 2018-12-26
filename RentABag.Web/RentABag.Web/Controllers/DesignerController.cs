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
    public class DesignerController : Controller
    {
        private const string homeControllerName = "Home";
        private const string administratorRole = "Administrator";
        private const string detailsName = "Details";
        private const string designerName = "Designer";

        private readonly IDesignersService designersService;

        public DesignerController(IDesignersService designersService)
        {
            this.designersService = designersService;
        }

        // GET: Designer
        [Authorize(Roles = administratorRole)]
        public ActionResult Index()
        {
            var allDesigners = this.designersService.GetAllDesigners();

            return View(allDesigners);
        }

        // GET: Designer/Details/5
        public ActionResult Details(int id)
        {
            var designer = this.designersService.GetDesignerById(id);

            if (designer == null)
            {
                return RedirectToAction(nameof(Index), homeControllerName);
            }

            return View(designer);
        }

        // GET: Designer/Create
        [Authorize(Roles = administratorRole)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Designer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = administratorRole)]
        public ActionResult Create(CreateDesignerViewModel vm)
        {
            if (ModelState.IsValid)
            {
                int designerId = this.designersService.CreateDesigner(vm);

                return RedirectToAction(detailsName ,designerName, new { id = designerId });
            }
            else
            {
                return View();
            }
        }

        // GET: Designer/Edit/5
        [Authorize(Roles = administratorRole)]
        public ActionResult Edit(int id)
        {
            var designer = this.designersService.GetDesignerById(id);

            if (designer == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var designerViewModel = new DesignerViewModel()
            {
                Description = designer.Description,
                FullName = designer.FullName,
                Image = designer.Image,
                Id = designer.Id
            };
            
            return View(designerViewModel);
        }

        // POST: Designer/Edit/5
        [Authorize(Roles =administratorRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateDesignerViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var designer = this.designersService.GetDesignerById(id);

                if (designer == null)
                {
                    return RedirectToAction(nameof(Index), homeControllerName);
                }

                int designerId = this.designersService.EditDesigner(vm, designer);

                return RedirectToAction(detailsName, designerName, new { id = designerId });
            }
            else
            {
                var designer = this.designersService.GetDesignerById(id);

                if (designer == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                var designerViewModel = new DesignerViewModel()
                {
                    Description = designer.Description,
                    FullName = designer.FullName,
                    Image = designer.Image,
                    Id = designer.Id
                };

                return View(designerViewModel);
            }
        }

        // GET: Designer/Delete/5
        [Authorize(Roles =administratorRole)]
        public ActionResult Delete(int id)
        {
            try
            {
                var designer = this.designersService.GetDesignerById(id);

                if (designer == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                this.designersService.DeleteDesigner(designer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}