using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirst.Models;
using LinQ.Models;

namespace LinQ.Controllers
{
    public class RevenueController : Controller
    {
        EShopV10 dbc = new EShopV10();

        // GET: Revenue
        public ActionResult Index()
        {
            var model = dbc.OrderDetails.GroupBy(x => x.Product).Select(g => new RevenueInfo
            {
                Nhom = g.Key.Name,
                DoanhSo = g.Sum(x => x.UnitPrice * x.Quantity),
                TongSoHHDB = g.Sum(x => x.Quantity),
                GiaNN = g.Min(x => x.UnitPrice),
                GiaLN = g.Max(x => x.UnitPrice),
                GiaTB = g.Average(x => x.UnitPrice)
            });
            return View("Index", model);
        }

        public ActionResult ByCategory()
        {
            var model = dbc.OrderDetails
                .GroupBy(d => d.Product.Category)
                .Select(g => new RevenueInfo
                {
                    Nhom = g.Key.NameVN,
                    DoanhSo = g.Sum(p => p.UnitPrice * p.Quantity),
                    TongSoHHDB = g.Sum(p => p.Quantity),
                    GiaNN = g.Min(p => p.UnitPrice),
                    GiaLN = g.Max(p => p.UnitPrice),
                    GiaTB = g.Average(p => p.UnitPrice)
                });
            return View("Index", model);
        }

        public ActionResult ByCustomer()
        {
            var model = dbc.OrderDetails
                .GroupBy(d => d.Order.CustomerId)
                .Select(g => new RevenueInfo
                {
                    Nhom = g.Key,
                    DoanhSo = g.Sum(p => p.UnitPrice * p.Quantity),
                    TongSoHHDB = g.Sum(p => p.Quantity),
                    GiaNN = g.Min(p => p.UnitPrice),
                    GiaLN = g.Max(p => p.UnitPrice),
                    GiaTB = g.Average(p => p.UnitPrice)
                });
            return View("Index", model);
        }

        public ActionResult ByYear()
        {
            var model = dbc.OrderDetails
                .GroupBy(d => d.Order.OrderDate.Year)
                .ToList()
                .Select(g => new RevenueInfo
                {
                    Nhom = g.Key.ToString(),
                    DoanhSo = g.Sum(p => p.UnitPrice * p.Quantity),
                    TongSoHHDB = g.Sum(p => p.Quantity),
                    GiaNN = g.Min(p => p.UnitPrice),
                    GiaLN = g.Max(p => p.UnitPrice),
                    GiaTB = g.Average(p => p.UnitPrice)
                });
            return View("Index", model);
        }
    }
}