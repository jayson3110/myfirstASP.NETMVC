using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductStock.Models;


namespace ProductStock.Controllers
{
    public class DemoController : Controller
    {
        private ProductDBContext db = new ProductDBContext();
        // GET: Demo
        public ActionResult Index()
        {
            var product = from e in db.Products
                          orderby e.ID
                          select e;
            return View(product);
        }

        // GET: Demo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Demo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Demo/Create
        [HttpPost]
        public ActionResult Create(Product newProduct)
        {
            try
            {
                // TODO: Add insert logic here

                db.Products.Add(newProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Demo/Edit/5
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

        // GET: Demo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Demo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


       
    }
}
