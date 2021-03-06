﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExtractionStore.Models;
using PagedList;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ExtractionStore.Controllers
{
    [Authorize(Roles ="Admin")]
    public class FileController : Controller
    {
        //create instance of database
        private ExtractionStoreDb db = new ExtractionStoreDb();

        //autocompletes on the search bar for the first ten matching file names that have been uploaded to the db
        //parameters: the file name to search for as a string
        //returns the items in json format so they can be displayed and selected from the search bar drop down
        public ActionResult Autocomplete(string term)
        {
            var model =
                db.Files
                .Where(f => f.FileName.StartsWith(term))
                .Take(10)
                .Select(f => new
                {
                    label = f.FileName
                });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //used to display the first 10 items after a search has been submitted on the analysis page
        //if no search term has been entered, then the first 10 items in alphabetical order are displayed
        //the results are pageable and returned on the file partial view
        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            var model =
                db.Files
                .OrderBy(f => f.FileName)
                .Where(f => searchTerm == null || f.FileName.Contains(searchTerm))
                .ToPagedList(page, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Files", model);
            }

            return View(model);
        }

        // GET: File/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            File file = db.Files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        // GET: File/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: File/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //edited so that on creation of a new db record, an actual file can be uploaded using HttpPostedFileBase, part of System.Web
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FileName,ContentType,Content")] File file, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                //check to make sure the file has content
                if (upload != null && upload.ContentLength > 0)
                {
                    //identify who the current user is
                    ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

                    //create a file instance and assign it values from the HttpPostedFileBase
                    file = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        UserName = user.UserName,
                        ContentType = upload.ContentType
                    };

                    //read in file content
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        file.Content = reader.ReadBytes(upload.ContentLength);
                    }

                    //check to make sure the file is a pdf
                    if (file.ContentType != "application/pdf")
                    {
                        ModelState.AddModelError("ContentType", "Invalid file type.  Only PDF files are accepted.");
                        return View(file);
                    }
                }
                //store new file in the db
                db.Files.Add(file);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(file);
        }

        // GET: File/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            File file = db.Files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        // POST: File/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FileName,ContentType")] File file)
        {
            if (ModelState.IsValid)
            {
                db.Entry(file).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(file);
        }

        // GET: File/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            File file = db.Files.Find(id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }

        // POST: File/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            File file = db.Files.Find(id);
            db.Files.Remove(file);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
