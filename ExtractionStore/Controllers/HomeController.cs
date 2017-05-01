using ExtractionStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExtractionStore.Controllers
{
    public class HomeController : Controller
    {
        ExtractionStoreDb _db = new ExtractionStoreDb();

        public ActionResult Index()
        {
            var model = _db.Files.ToList();

            return View(model);
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

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}