using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cobom.Models;
using System.IO;

namespace cobom.Controllers
{
    [Authorize]
    public class downloadFilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: downloadFiles
        public ActionResult Index()
        {
            return View(db.downloadFiles.ToList());
        }

        // GET: downloadFiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            downloadFile downloadFile = db.downloadFiles.Find(id);
            if (downloadFile == null)
            {
                return HttpNotFound();
            }
            return View(downloadFile);
        }

        // GET: downloadFiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: downloadFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,description")] downloadFile DownloadFile, HttpPostedFileBase Name)
        {

            if (ModelState.IsValid)
            {
                if (Name != null)
                {
                    DownloadFile.Name = Name.FileName;
                    string path = Path.Combine(Server.MapPath("~/download"), Path.GetFileName(Name.FileName));
                    Name.SaveAs(path);
                }

                db.downloadFiles.Add(DownloadFile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(DownloadFile);
        }

        [HttpPost]
        public FileResult DownloadFile(int? fileId)
        {
           
            downloadFile file = db.downloadFiles.ToList().Find(p => p.ID == fileId.Value);
            return File(file.Data, file.ContentType, file.Name);
        }

        // GET: downloadFiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            downloadFile downloadFile = db.downloadFiles.Find(id);
            if (downloadFile == null)
            {
                return HttpNotFound();
            }
            return View(downloadFile);
        }

        // POST: downloadFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ContentType,Data")] downloadFile downloadFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(downloadFile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(downloadFile);
        }

        // GET: downloadFiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            downloadFile downloadFile = db.downloadFiles.Find(id);
            if (downloadFile == null)
            {
                return HttpNotFound();
            }
            return View(downloadFile);
        }

        // POST: downloadFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            downloadFile downloadFile = db.downloadFiles.Find(id);
            db.downloadFiles.Remove(downloadFile);
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
