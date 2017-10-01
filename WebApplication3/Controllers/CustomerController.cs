using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class CustomerController : Controller
    {
        EShopV10Entities dbc = new EShopV10Entities();

        // GET: Customer
        public ActionResult Index()
        {
            ViewBag.Item = dbc.Customers.ToList();
            return View();
        }

        public ActionResult Insert(Customer model)
        {
            var uploadPhoto = Request.Files["upPhoto"];

            if (uploadPhoto.ContentLength > 0)
            {
                model.Photo = uploadPhoto.FileName;
                var path = Server.MapPath("~/Images/Customer/" + model.Photo);
                uploadPhoto.SaveAs(path);
            }
            else
            {
                model.Photo = "User.png";
            }

            try
            {
                dbc.Customers.Add(model);
                dbc.SaveChanges();

                //ModelState.AddModelError("", "Add Succesfully");
                //ModelState.Clear();
            }

            catch
            {
                //ModelState.AddModelError("","Add Error");
            }

            ViewBag.Item = dbc.Customers.ToList();
            return View("Index");
        }

        public ActionResult Update(Customer model)
        {
            var uploadPhoto = Request.Files["upPhoto"];

            if (uploadPhoto.ContentLength > 0)
            {
                model.Photo = uploadPhoto.FileName;
                var path = Server.MapPath("~/Images/Customer/" + model.Photo);
                uploadPhoto.SaveAs(path);
            }
            
            dbc.Entry(model).State = System.Data.Entity.EntityState.Modified;
            dbc.SaveChanges();

            ViewBag.Item = dbc.Customers.ToList();
            return View("Index");
        }

        public ActionResult Edit(String id)
        {
            var cust = dbc.Customers.Find(id);

            ViewBag.Item = dbc.Customers.ToList();
            return View("Index", cust);
        }

        public ActionResult Delete(String id)
        {
            var cust = dbc.Customers.Find(id);

            if (cust != null)
            {
                dbc.Customers.Remove(cust);
                dbc.SaveChanges();
            }

            ViewBag.ItemList = dbc.Customers.ToList();
            return View("Index");
        }

    }
}