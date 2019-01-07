using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentABag.Models;
using RentABag.Web.Helpers;
using RentABag.Web.Services.Contracts;
using RentABag.Web.ViewModels;

namespace RentABag.Web.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessagesService messagesService;

        public MessageController(IMessagesService messagesService)
        {
            this.messagesService = messagesService;
        }

        // GET: Designer
        [Authorize(Roles = Constants.administratorRole)]
        public ActionResult Index()
        {
            var allMessages = this.messagesService.GetAllMessages().ToList();

            if (allMessages == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            return View(allMessages);
        }

        // GET: Designer/Details/5
        [Authorize(Roles = Constants.administratorRole)]
        public ActionResult Details(int id)
        {
            var message = this.messagesService.GetMessageById(id);

            if (message == null)
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }

            return View(message);
        }

        // GET: Designer/Delete/5
        [Authorize(Roles = Constants.administratorRole)]
        public ActionResult Delete(int id)
        {
            try
            {
                var message = this.messagesService.GetMessageById(id);

                if (message == null)
                {
                    return RedirectToAction(Constants.errorName, Constants.homeControllerName);
                }

                this.messagesService.DeleteMessageAsync(message);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(Constants.errorName, Constants.homeControllerName);
            }
        }
    }
}