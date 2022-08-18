using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakipOtomasyonu.Models.Entity;

namespace StokTakipOtomasyonu.Controllers
{
    public class CategoriesController : Controller
    {
        StokOtomasyonDBEntities db = new StokOtomasyonDBEntities();
        // GET: Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        public ActionResult Add() 
        {
            return View();
        }
        public ActionResult Add2(Categories parameter)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            db.Categories.Add(parameter);
            db.SaveChanges();
            return RedirectToAction("Index"); // return the lıst page after adding
        }
        public ActionResult Update(Categories parameter)
        {
            var model = db.Categories.Find(parameter.ID);
            if (model == null) return HttpNotFound(); // Redirect to error page
            return View(model);
            //Index page link
        }

        public ActionResult Update_Save(Categories parameter)
        {
            db.Entry(parameter).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete( Categories parameter)
        {
            var model = db.Categories.Find(parameter.ID);
            if (model == null) return HttpNotFound();
            return View(model);
        }

        public ActionResult Delete_Save(Categories parameter)
        {
            db.Entry(parameter).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}