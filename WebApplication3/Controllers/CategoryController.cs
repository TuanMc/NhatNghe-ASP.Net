using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class CategoryController : Controller
    {
        EShopV10Entities dbc = new EShopV10Entities();

        // GET: Category
        public ActionResult Index()
        {
            ViewBag.ItemList = dbc.Categories.ToList();
            return View();
        }

        public ActionResult Insert(Category model)
        {
            try
            {
                dbc.Categories.Add(model);
                dbc.SaveChanges();
                ModelState.AddModelError("", "Insert Success!!!");
                ModelState.Clear();
            }

            catch
            {
                ModelState.AddModelError("", "Insert Error!!!");
            }

            
            ViewBag.ItemList = dbc.Categories.ToList();
            return View("Index");
        }

        public ActionResult Edit(int id)
        {
            var item = dbc.Categories.Find(id);

            ViewBag.ItemList = dbc.Categories.ToList();
            return View("Index", item);
        }

        public ActionResult Update(Category model)
        {
            dbc.Entry(model).State = System.Data.Entity.EntityState.Modified;
            dbc.SaveChanges();

            ViewBag.ItemList = dbc.Categories.ToList();
            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            var item = dbc.Categories.Find(id);
            dbc.Categories.Remove(item);
            dbc.SaveChanges();
            ModelState.Clear();

            ViewBag.ItemList = dbc.Categories.ToList();
            return View("Index");
        }
    }
}