﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wine_API.Controllers
{
    public class WineController : Controller
    {
        [HttpGet("{id}")]
        public ActionResult GetWine(int WineId)
        {
            return View();
        }

        // GET: Wine/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Wine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wine/Create
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

        // GET: Wine/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Wine/Edit/5
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

        // GET: Wine/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Wine/Delete/5
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