using EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinQ.Controllers
{
    public class PagingController : Controller
    {
        EShopV10 dbc = new EShopV10();

        // GET: Paging
        public ActionResult Index(int PageNo = 0, int PageSize = 10 )
        {
            var result = dbc.Products.OrderBy(n => n.Id).Skip(PageNo * PageSize).Take(PageSize).ToList();

            int pages = (dbc.Products.Count() -1 )/ PageSize;
            ViewBag.PageMax = pages;
            ViewBag.PageNo = PageNo;
            ViewBag.Items = result;
            return View();
        }
    }
}