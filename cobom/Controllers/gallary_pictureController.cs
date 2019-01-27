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
    public class gallary_pictureController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: gallary_picture
        public ActionResult Index()
        {
            return View(db.gallary_picture.ToList());
        }

        // GET: gallary_picture/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gallary_picture gallary_picture = db.gallary_picture.Find(id);
            if (gallary_picture == null)
            {
                return HttpNotFound();
            }
            return View(gallary_picture);
        }

        // GET: gallary_picture/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: gallary_picture/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,details")] gallary_picture gallary_picture, HttpPostedFileBase imgurl)
        {
            if (ModelState.IsValid)
            {
                gallary_picture.imgurl = imgurl.FileName;

                db.gallary_picture.Add(gallary_picture);

                if (imgurl != null)
                {
                    string path = Path.Combine(Server.MapPath("~/images/gallery"), Path.GetFileName(imgurl.FileName));
                    imgurl.SaveAs(path);
                }
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(gallary_picture);
        }

        // GET: gallary_picture/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gallary_picture gallary_picture = db.gallary_picture.Find(id);
            if (gallary_picture == null)
            {
                return HttpNotFound();
            }
            return View(gallary_picture);
        }

        // POST: gallary_picture/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,details,imgurl")] gallary_picture gallary_picture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gallary_picture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gallary_picture);
        }

        // GET: gallary_picture/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gallary_picture gallary_picture = db.gallary_picture.Find(id);
            if (gallary_picture == null)
            {
                return HttpNotFound();
            }
            return View(gallary_picture);
        }

        // POST: gallary_picture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gallary_picture gallary_picture = db.gallary_picture.Find(id);
            db.gallary_picture.Remove(gallary_picture);
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
