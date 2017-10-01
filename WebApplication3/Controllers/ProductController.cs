using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ProductController : Controller
    {
        EShopV10Entities dbc = new EShopV10Entities();

        public ActionResult ListByCategory(int id)
        {
            var model = dbc.Categories.Find(id);
            return View("List", model);
        }

        public ActionResult Detail(int id)
        {
            var model = dbc.Products.Find(id);
            return View("Detail", model);
        }
    }
}