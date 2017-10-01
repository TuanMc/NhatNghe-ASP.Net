using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirst.Models;


namespace LinQ.Controllers
{
    public class HomeController : Controller
    {
        EShopV10 dbc = new EShopV10();

        public ActionResult Index()
        {
            ViewBag.Products = dbc.Products.OrderBy(x => Guid.NewGuid())
                .Take(4)
                .ToList();

            ViewBag.Categories = dbc.Categories.Where(c => c.Products.Count() >= 5)
                .OrderBy(x => Guid.NewGuid())
                .Take(3)
                .ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}