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
    public class newscategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: newscategories
        public ActionResult Index()
        {
            return View(db.newscategories.ToList());
        }

        // GET: newscategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            newscategory newscategory = db.newscategories.Find(id);
            if (newscategory == null)
            {
                return HttpNotFound();
            }
            return View(newscategory);
        }

        // GET: newscategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: newscategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,category,order")] newscategory newscategory)
        {
            if (ModelState.IsValid)
            {
                db.newscategories.Add(newscategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newscategory);
        }

        // GET: newscategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            newscategory newscategory = db.newscategories.Find(id);
            if (newscategory == null)
            {
                return HttpNotFound();
            }
            return View(newscategory);
        }

        // POST: newscategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,category,order")] newscategory newscategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newscategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newscategory);
        }

        // GET: newscategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            newscategory newscategory = db.newscategories.Find(id);
            if (newscategory == null)
            {
                return HttpNotFound();
            }
            return View(newscategory);
        }

        // POST: newscategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            newscategory newscategory = db.newscategories.Find(id);
            db.newscategories.Remove(newscategory);
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
