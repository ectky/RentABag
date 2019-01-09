using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentABag.Models;
using RentABag.Services.Common;
using RentABag.ViewModels;
using RentABag.Web.Helpers;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RentABag.Web.Areas.Administrator.Controllers
{
    [Area(Constants.administratorRole)]
    [Authorize(Roles = Constants.administratorRole)]
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
        public ActionResult Index()
        {
            var allDesigners = designersService.GetAllDesigners().ToList();

            return View(allDesigners);
        }

        // GET: Designer/Details/5
        [Route(Constants.designerDetails)]
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var designer = designersService.GetDesignerById(id);

            if (designer == null)
            {
                return RedirectToAction(nameof(Index), homeControllerName);
            }

            return View(designer);
        }

        // GET: Designer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Designer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateDesignerViewModel vm, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                int designerId = await designersService.CreateDesignerAsync(vm, file);

                return RedirectToAction(detailsName, designerName, new { id = designerId });
            }
            else
            {
                return View();
            }
        }

        // GET: Designer/Edit/5
        public ActionResult Edit(int id)
        {
            var designer = designersService.GetDesignerById(id);

            if (designer == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var designerViewModel = Mapper.Map<Designer, DesignerViewModel>(designer);

            designerViewModel.Image = null;

            return View(designerViewModel);
        }

        // POST: Designer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CreateDesignerViewModel vm, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var designer = designersService.GetDesignerById(id);

                if (designer == null)
                {
                    return RedirectToAction(nameof(Index), homeControllerName);
                }

                int designerId = await designersService.EditDesignerAsync(vm, designer, file);

                return RedirectToAction(detailsName, designerName, new { id = designerId });
            }
            else
            {
                var designer = designersService.GetDesignerById(id);

                if (designer == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                var designerViewModel = new DesignerViewModel()
                {
                    Description = designer.Description,
                    Name = designer.Name,
                    Image = designer.Image,
                    Id = designer.Id
                };

                return View(designerViewModel);
            }
        }

        // GET: Designer/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var designer = designersService.GetDesignerById(id);

                if (designer == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                designersService.DeleteDesignerAsync(designer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}