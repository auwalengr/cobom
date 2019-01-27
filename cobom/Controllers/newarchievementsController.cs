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
    public class newarchievementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: newarchievements
        public ActionResult Index()
        {
            return View(db.newarchievement.ToList());
        }

        // GET: newarchievements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            newarchievement newarchievement = db.newarchievement.Find(id);
            if (newarchievement == null)
            {
                return HttpNotFound();
            }
            return View(newarchievement);
        }

        // GET: newarchievements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: newarchievements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,type,unit")] newarchievement newarchievement)
        {
            if (ModelState.IsValid)
            {
                db.newarchievement.Add(newarchievement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newarchievement);
        }

        // GET: newarchievements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            newarchievement newarchievement = db.newarchievement.Find(id);
            if (newarchievement == null)
            {
                return HttpNotFound();
            }
            return View(newarchievement);
        }

        // POST: newarchievements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,type,unit")] newarchievement newarchievement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newarchievement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newarchievement);
        }

        // GET: newarchievements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            newarchievement newarchievement = db.newarchievement.Find(id);
            if (newarchievement == null)
            {
                return HttpNotFound();
            }
            return View(newarchievement);
        }

        // POST: newarchievements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            newarchievement newarchievement = db.newarchievement.Find(id);
            db.newarchievement.Remove(newarchievement);
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
