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
            return View();
        }

        [Authorize]
        public ActionResult Upload()
        {
            ViewBag.Message = "Your application upload page.";
            
            return View();
        }

        public ActionResult Analysis(string searchTerm = null)
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