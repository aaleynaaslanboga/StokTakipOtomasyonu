using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakipOtomasyonu.Models.Entity;

namespace StokTakipOtomasyonu.Controllers
{
    public class BrandController : Controller
    {
        StokOtomasyonDBEntities db = new StokOtomasyonDBEntities();
        // GET: Brand
        public ActionResult Brand()
        {
            var model = db.Brands.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            //DropDownList data transfer to add.cshtml
            var model = new Brands();
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Category", model.CategoryID);
            return View();
        }

        [HttpPost]
        public ActionResult Add(Brands parameter)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Category", parameter.CategoryID);
                return View();
            }
            db.Entry(parameter).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Brand");
        }
    }
}
