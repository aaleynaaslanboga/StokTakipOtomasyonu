using StokTakipOtomasyonu.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StokTakipOtomasyonu.Controllers
{
    public class ProductsController : Controller
    {
        StokOtomasyonDBEntities db = new StokOtomasyonDBEntities();
        // GET: Products
        public ActionResult Product()
        {
            var model = db.Products.ToList();
            return View(model);
            
        }
        [HttpGet] //call the page
        public ActionResult Add()
        {
            // fill the dropdown list items from models list category and unit 
            // created two list in the products model for dropdownlist

            var model = new Products();
            Refresh(model);
            return View(model);
        }

        private void Refresh(Products model)
        {
            List<Categories> categorylist = db.Categories.OrderBy(x => x.Category).ToList();
            model.CategoryList = (from x in categorylist
                                  select new SelectListItem
                                  {
                                      Text = x.Category,
                                      Value = x.ID.ToString()
                                  }).ToList();
            List<Units> unitlist = db.Units.OrderBy(x => x.Unit).ToList();
            model.UnitList = (from x in unitlist
                              select new SelectListItem
                              {
                                  Text = x.Unit,
                                  Value = x.ID.ToString()
                              }).ToList();
        }

        [HttpPost] // process the page load
        public ActionResult Add(Products parameter)
        {
            return View("Product");
        }

        [HttpPost]
        public JsonResult GetBrand(int id)
        {
            var model = new Products();
            List<Brands> brandlist = db.Brands.Where(x => x.CategoryID == id).OrderBy(x => x.Brand).ToList();
            model.BrandList = (from x in brandlist
                               select new SelectListItem
                               {
                                   Text = x.Brand,
                                   Value = x.ID.ToString()
                               }
                               ).ToList();
            model.BrandList.Insert(0, new SelectListItem { Text = "Select", Value = "" });
            return Json(model.BrandList, JsonRequestBehavior.AllowGet);
        }
    }
}