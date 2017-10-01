using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFCodeFirst.Models;

namespace LinQ.Controllers
{
    public class AccountController : Controller
    {
        EShopV10 dbc = new EShopV10();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(String Id, String Password)
        {
            //var user = dbc.Customers.Find(Id);
            //if (user == null)
            //{
            //    ModelState.AddModelError("", "Sai ten dang nhap");
            //}
            //else if (Password != user.Password)
            //{
            //    ModelState.AddModelError("", "Sai mat khau");
            //}

            //else
            //    ModelState.AddModelError("","Dang nhap thanh cong");

            try
            {
                var user = dbc.Customers.Single(c => c.Id == Id);
                if (Password != user.Password)
                {
                    ModelState.AddModelError("", "Sai mat khau");
                }
                else
                    ModelState.AddModelError("", "Dang nhap thanh cong");
            }
            catch
            {
                ModelState.AddModelError("", "Sai ten dang nhap");
            }

            return View();
        }
    }
}