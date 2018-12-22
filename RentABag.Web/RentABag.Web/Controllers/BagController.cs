﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentABag.Web.Controllers
{
    public class BagController : Controller
    {
        // GET: Bag
        public ActionResult Index()
        {
            return View();
        }

        // GET: Bag/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bag/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bag/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Bag/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bag/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Bag/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bag/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}