using LinQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinQ.Controllers
{
    public class LinQController : Controller
    {
        int[] number = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        // GET: LinQ
        public ActionResult Demo1()
        {
            //var result = from n in number
            //             where n % 2 == 0
            //             select n;
            var result = number.Where(n => n % 2 == 0).Select(n => n);
            ViewBag.items = result;
            return View();
        }

        public ActionResult Demo2()
        {
            //var result = from n in number
            //             where n % 2 == 0
            //             select n;
            
            var result = number.Where(n => n % 2 == 0).Select(n => new NumberInfo { Value = n, Rate = (float)n/number.Sum() });

            
            //var result3 = number.GroupBy(n => n % 3).Select(g => new
            //{
            //    // Can phai khai bao 1 model co kiu nhu sau:
            //    Nhom = g.Key,
            //    Tong = g.Sum(),
            //    SoLuong = g.Count(),
            //    SoNN = g.Min(),
            //    SoLN = g.Max(),
            //    SoTB = g.Average()
            //});

            ViewBag.items = result;
            //ViewBag.items3 = result3;
            return View();
        }
    }
}