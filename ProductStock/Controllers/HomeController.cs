using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductStock.Models;

namespace ProductStock.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private ProductDBContext db = new ProductDBContext();
        [OutputCache(Duration = 600)]
        public ActionResult Index()
        {
            var product = from e in db.Products
                          orderby e.ID
                            select e;
            return View(product);

        }


        public ActionResult Camera()
        {
            var product = from e in db.Products
                          orderby e.ID
                          where e.Category == "Camera"
                          select e ;
            return View(product);

        }

        public ActionResult Laptop()
        {
            var product = from e in db.Products
                          orderby e.ID
                          where e.Category == "Laptop"
                          select e;
            return View(product);

        }

        public ActionResult Iphone()
        {
            var product = from e in db.Products
                          orderby e.ID
                          where e.Category == "Iphone"
                          select e;
            return View(product);

        }

        public ActionResult MacBook()
        {
            var product = from e in db.Products
                          orderby e.ID
                          where e.Category == "MacBook"
                          select e;
            return View(product);

        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product newProduct)
        {



            db.Products.Add(newProduct);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        public ActionResult Edit(int id)
        {
            var product = db.Products.Single(m => m.ID == id);
            return View(product);
        }

        // POST: Demo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var product = db.Products.Single(m => m.ID == id);
                if (TryUpdateModel(product))
                {
                    //To Do:- database code
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View();
            }
        }




        [ChildActionOnly]
        public ActionResult TemplateProduct ()
        {
            return PartialView("TemplateProduct");
            
        }

        [ChildActionOnly]
        public ActionResult InventoryStatus()
        {
            return PartialView("_Layout");

        }


    }
}