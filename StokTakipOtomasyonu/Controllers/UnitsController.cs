using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokTakipOtomasyonu.Models.Entity;

namespace StokTakipOtomasyonu.Controllers
{
    public class UnitsController : Controller
    {
        StokOtomasyonDBEntities db = new StokOtomasyonDBEntities();
        // GET: Units
        public ActionResult Unit()
        {
            return View(db.Units.ToList());
        }
        //public ActionResult UnitAley()
        //{
        //    ViewBag.message = "Hello WOrld22";
        //    ViewBag.Title = "Hello WOrld";

        //    return View(db.Categories.ToList());
        //    //return View();

        [HttpGet]
        public ActionResult Add()
        {
            return View("Add");
        }
        [HttpPost]
        public ActionResult Add(Units param)
        {
            if (!ModelState.IsValid)
            {
                return View("Add");
            }
            db.Units.Add(param);
            db.SaveChanges();
            return RedirectToAction("Unit");
        }

        public ActionResult Update(int ID)
        {
            var model = db.Units.Find(ID);
            if (model == null) return HttpNotFound(); // Redirect to error page
            return View(model);
            //Index page link
        }

        public ActionResult Update_Save(Units parameter)
        {
            db.Entry(parameter).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Unit");
        }
        public ActionResult Delete(Units parameter)
        {
            var model = db.Units.Find(parameter.ID);
            if (model == null) return HttpNotFound();
            return View(model);
        }

        public ActionResult Delete_Save(Units parameter)
        {
            db.Entry(parameter).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Unit");

        }

    }
}