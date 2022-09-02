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
        [HttpGet]
        public ActionResult Add()
        {
            return View("Add");
        }
        [HttpPost]
        public ActionResult Add(Categories p)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            db.Categories.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Update(int ID) // the page dısplay when clıck the update button
        {
            var model = db.Categories.Find(ID);
            if (model == null) return HttpNotFound(); // Redirect to error page
            return View(model);
            //Index page link
        }

        public ActionResult Update_Save(Categories parameter) // Function method when the user make any change in update page (Form Actıon)
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