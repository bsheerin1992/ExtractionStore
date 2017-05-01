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

        public ActionResult Upload()
        {
            ViewBag.Message = "Your application upload page.";
            
            return View();
        }

        public ActionResult Analysis(string searchTerm = null)
        {
            ViewBag.Message = "Your analysis page.";

            var model =
                _db.Files
                   .OrderBy(f => f.Name)
                   .Where(f => searchTerm == null || f.Name.Contains(searchTerm));

            return View(model);
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