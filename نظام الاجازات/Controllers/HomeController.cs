using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace نظام_الاجازات.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["UserType"]==null || Session["UserID"]==null)
            {
                RedirectToAction("Index", "LogIn");
            }
            return View();
        }
    }
}