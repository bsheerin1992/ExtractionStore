using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExtractionStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            ViewBag.Message = "Your application upload page.";

            return View();
        }

        public ActionResult Analysis()
        {
            ViewBag.Message = "Your analysis page.";

            return View();
        }
    }
}