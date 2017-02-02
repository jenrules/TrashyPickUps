using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trash.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your Trash Collectors And What We Do.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your Trash Collectors Contact Page.";

            return View();
        }
    }
}