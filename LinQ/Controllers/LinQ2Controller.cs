using EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinQ.Models;

namespace LinQ.Controllers
{
    public class LinQ2Controller : Controller
    {
        EShopV10 dbc = new EShopV10();
        // GET: LinQ2
        public ActionResult Index()
        {
            var results = dbc.Products
                .Where(p => p.UnitPrice >= 5 && p.UnitPrice <= 10)
                .Select(p => p).ToList();
            ViewBag.Items = results;
            return View();
        }

        public ActionResult Index2()
        {
            var results = dbc.Products
                .GroupBy(p => p.Category)
                .Select(g => new ReportInfo
                {
                    Nhom = g.Key.NameVN,
                    Tong = g.Sum(p => p.UnitPrice*p.Quantity),
                    SoLuong = g.Sum(p => p.Quantity),
                    GiaTB = g.Average(p => p.UnitPrice)
                }).ToList();
            ViewBag.Items = results;
            return View();
        }
    }
}