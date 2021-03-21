using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WineAPI.Controllers
{
    [Route("[controller]")]
    public class WineController : Controller
    {
        [Route("{Id}")]
        [HttpGet]
        public ActionResult GetWine(int WineId)
        {
            return NotFound();
        }

        // POST: Wine/Create
        //[HttpPost]
        //[ValIdateAntiForgeryToken]
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
        //public ActionResult Edit(int Id)
        //{
        //    return View();
        //}

        //// POST: Wine/Edit/5
        //[HttpPost]
        //[ValIdateAntiForgeryToken]
        //public ActionResult Edit(int Id, IFormCollection collection)
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
        //public ActionResult Delete(int Id)
        //{
        //    return View();
        //}

        //// POST: Wine/Delete/5
        //[HttpPost]
        //[ValIdateAntiForgeryToken]
        //public ActionResult Delete(int Id, IFormCollection collection)
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