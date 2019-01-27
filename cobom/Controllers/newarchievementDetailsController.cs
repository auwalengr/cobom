using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cobom.Models;

namespace cobom.Controllers
{
    public class newarchievementDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: newarchievementDetails
        public ActionResult Index()
        {
            var newarchievementDetails = db.newarchievementDetails.Include(n => n.newarchievement);
            return View(newarchievementDetails.ToList());
        }

        // GET: newarchievementDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            newarchievementDetail newarchievementDetail = db.newarchievementDetails.Find(id);
            if (newarchievementDetail == null)
            {
                return HttpNotFound();
            }
            return View(newarchievementDetail);
        }

        // GET: newarchievementDetails/Create
        public ActionResult Create()
        {
            ViewBag.newarchievementid = new SelectList(db.newarchievement, "id", "type");
            return View();
        }

        // POST: newarchievementDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,amount,date,newarchievementid")] newarchievementDetail newarchievementDetail)
        {
            if (ModelState.IsValid)
            {
                db.newarchievementDetails.Add(newarchievementDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.newarchievementid = new SelectList(db.newarchievement, "id", "type", newarchievementDetail.newarchievementid);
            return View(newarchievementDetail);
        }

        // GET: newarchievementDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            newarchievementDetail newarchievementDetail = db.newarchievementDetails.Find(id);
            if (newarchievementDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.newarchievementid = new SelectList(db.newarchievement, "id", "type", newarchievementDetail.newarchievementid);
            return View(newarchievementDetail);
        }

        // POST: newarchievementDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,amount,date,newarchievementid")] newarchievementDetail newarchievementDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newarchievementDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.newarchievementid = new SelectList(db.newarchievement, "id", "type", newarchievementDetail.newarchievementid);
            return View(newarchievementDetail);
        }

        // GET: newarchievementDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            newarchievementDetail newarchievementDetail = db.newarchievementDetails.Find(id);
            if (newarchievementDetail == null)
            {
                return HttpNotFound();
            }
            return View(newarchievementDetail);
        }

        // POST: newarchievementDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            newarchievementDetail newarchievementDetail = db.newarchievementDetails.Find(id);
            db.newarchievementDetails.Remove(newarchievementDetail);
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
