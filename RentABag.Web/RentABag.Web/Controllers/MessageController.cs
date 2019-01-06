using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentABag.Models;
using RentABag.Web.Services.Contracts;
using RentABag.Web.ViewModels;

namespace RentABag.Web.Controllers
{
    public class MessageController : Controller
    {
        private const string homeControllerName = "Home";
        private const string administratorRole = "Administrator";
        private const string detailsName = "Details";
        private const string designerName = "Designer";
        private const string errorName = "Error";

        private readonly IMessagesService messagesService;

        public MessageController(IMessagesService messagesService)
        {
            this.messagesService = messagesService;
        }

        // GET: Designer
        [Authorize(Roles = administratorRole)]
        public ActionResult Index()
        {
            var allMessages = this.messagesService.GetAllMessages().ToList();

            return View(allMessages);
        }

        // GET: Designer/Details/5
        public ActionResult Details(int id)
        {
            var message = this.messagesService.GetMessageById(id);

            if (message == null)
            {
                return RedirectToAction(errorName, homeControllerName);
            }

            return View(message);
        }

        // GET: Designer/Delete/5
        [Authorize(Roles =administratorRole)]
        public ActionResult Delete(int id)
        {
            try
            {
                var message = this.messagesService.GetMessageById(id);

                if (message == null)
                {
                    return RedirectToAction(errorName, homeControllerName);
                }

                this.messagesService.DeleteMessageAsync(message);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(errorName, homeControllerName);
            }
        }
    }
}