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
    public class archievementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: archievements
        public ActionResult Index()
        {
            return View(db.archievements.ToList());
        }

        // GET: archievements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            archievement archievement = db.archievements.Find(id);
            if (archievement == null)
            {
                return HttpNotFound();
            }
            return View(archievement);
        }

        // GET: archievements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: archievements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,type,details,location")] archievement archievement, HttpPostedFileBase imgurl)
        {
            if (ModelState.IsValid)
            {
                if (imgurl != null)
                {
                    archievement.imgurl = imgurl.FileName;
                    string path = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(imgurl.FileName));
                    imgurl.SaveAs(path);
                }
                db.archievements.Add(archievement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(archievement);
        }

        // GET: archievements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            archievement archievement = db.archievements.Find(id);
            if (archievement == null)
            {
                return HttpNotFound();
            }
            return View(archievement);
        }

        // POST: archievements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,type,details,location,imgurl")] archievement archievement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(archievement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(archievement);
        }

        // GET: archievements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            archievement archievement = db.archievements.Find(id);
            if (archievement == null)
            {
                return HttpNotFound();
            }
            return View(archievement);
        }

        // POST: archievements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            archievement archievement = db.archievements.Find(id);
            db.archievements.Remove(archievement);
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
