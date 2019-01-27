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
    [Authorize]
    public class coordinatorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: coordinators
        public ActionResult Index()
        {
            return View(db.coordinators.ToList());
        }

        // GET: coordinators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coordinator coordinator = db.coordinators.Find(id);
            if (coordinator == null)
            {
                return HttpNotFound();
            }
            return View(coordinator);
        }

        // GET: coordinators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: coordinators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,location,phone")] coordinator coordinator)
        {
            if (ModelState.IsValid)
            {
                db.coordinators.Add(coordinator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coordinator);
        }

        // GET: coordinators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coordinator coordinator = db.coordinators.Find(id);
            if (coordinator == null)
            {
                return HttpNotFound();
            }
            return View(coordinator);
        }

        // POST: coordinators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,location,phone")] coordinator coordinator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coordinator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coordinator);
        }

        // GET: coordinators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            coordinator coordinator = db.coordinators.Find(id);
            if (coordinator == null)
            {
                return HttpNotFound();
            }
            return View(coordinator);
        }

        // POST: coordinators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            coordinator coordinator = db.coordinators.Find(id);
            db.coordinators.Remove(coordinator);
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
