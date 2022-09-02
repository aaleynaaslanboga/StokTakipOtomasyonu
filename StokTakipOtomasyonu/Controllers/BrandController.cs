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
            SelectedInfo();
            return View();
        }

        private void SelectedInfo()
        {
            var model = new Brands();
            List<SelectListItem> list = new List<SelectListItem>(from x in db.Categories
                                                                 select new SelectListItem
                                                                 {
                                                                     Value = x.ID.ToString(),
                                                                     Text = x.Category
                                                                 }
                                                                 ).ToList();
            //ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Category", model.CategoryID);
            ViewBag.aleyna = list;
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


        public ActionResult Update(int ID)
        {
            SelectedInfo();
            var search  = db.Brands.Find(ID);
            if (search == null) return HttpNotFound(); // Redirect to error page
            return View(search);
        }

        public ActionResult Update_Save(Brands parameter)
        {
            if (!ModelState.IsValid)
            {
                SelectedInfo();
                return View("Update");
            }
            db.Entry(parameter).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Brand");
        }

        public ActionResult Delete(Brands param)
        {
            var item = db.Brands.Find(param.ID);
            return View(item);
        }

        public ActionResult Delete_Save(Brands param)
        {
            db.Entry(param).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Brand");
        }
    }

    }
