using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wine_API.Controllers
{
    [Route("[controller]")]
    public class WineController : Controller
    {
        [Route("{id}")]
        [HttpGet]
        public ActionResult GetWine(int WineId)
        {
            return NotFound();
        }

        // POST: Wine/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction();
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Wine/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Wine/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction();
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Wine/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Wine/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction();
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}