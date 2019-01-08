using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentABag.Services.Common;
using RentABag.Web.Helpers;
using System.Linq;

namespace RentABag.Web.Areas.Administrator.Controllers
{
    [Area(Constants.administratorRole)]
    [Authorize(Roles = Constants.administratorRole)]
    public class MessageController : Controller
    {
        private readonly IMessagesService messagesService;

        public MessageController(IMessagesService messagesService)
        {
            this.messagesService = messagesService;
        }

        // GET: Designer
        public ActionResult Index()
        {
            var allMessages = messagesService.GetAllMessages().ToList();

            if (allMessages == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            return View(allMessages);
        }

        // GET: Designer/Details/5
        public ActionResult Details(int id)
        {
            var message = messagesService.GetMessageById(id);

            if (message == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            return View(message);
        }

        // GET: Designer/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var message = messagesService.GetMessageById(id);

                if (message == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }

                messagesService.DeleteMessageAsync(message);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }
        }
    }
}