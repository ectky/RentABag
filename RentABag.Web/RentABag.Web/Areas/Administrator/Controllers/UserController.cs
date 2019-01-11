using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentABag.Helpers;
using RentABag.Services.Common;

namespace RentABag.Web.Areas.Administrator.Controllers
{
    [Area(Constants.administratorRole)]
    [Authorize(Roles = Constants.administratorRole)]
    public class UserController : Controller
    {
        private readonly IUsersService usersService;

        public UserController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        // GET: Designer
        public ActionResult Index()
        {
            var allusers = usersService.GetAllUsers();

            if (allusers == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            return View(allusers);
        }

        // GET: Designer/Delete/5
        public ActionResult Administrate(string id)
        {
            try
            {
                usersService.MakeAdministratorrAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }
        }

        // GET: Designer/Delete/5
        public ActionResult DeAdministrate(string id)
        {
            try
            {
                usersService.DeAdministrateAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }
        }
    }
}