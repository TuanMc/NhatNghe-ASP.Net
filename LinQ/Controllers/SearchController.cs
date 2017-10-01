using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirst.Models;

namespace LinQ.Controllers
{
    public class SearchController : Controller
    {
        EShopV10 dbc = new EShopV10();
        // GET: Search
        public ActionResult Index(double min=0, double max=double.MaxValue, String keyword = "")
        {
            ViewBag.Items = dbc.Products.Where(x => x.UnitPrice >= min && x.UnitPrice <= max)
                        .Where(x => x.Name.Contains(keyword) || x.Category.Name.Contains(keyword) || x.Category.NameVN.Contains(keyword))
                        .OrderBy(x => x.UnitPrice)
                        .ToList();
            return View();
        }
    }
}