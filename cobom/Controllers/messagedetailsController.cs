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
    public class messagedetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: messagedetails
        public ActionResult Index()
        {
            return View(db.messagedetails.ToList());
        }

        // GET: messagedetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            messagedetail messagedetail = db.messagedetails.Find(id);
            if (messagedetail == null)
            {
                return HttpNotFound();
            }
            return View(messagedetail);
        }

        // GET: messagedetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: messagedetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,body,title,fa")] messagedetail messagedetail)
        {
            if (ModelState.IsValid)
            {
                db.messagedetails.Add(messagedetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(messagedetail);
        }

        // GET: messagedetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            messagedetail messagedetail = db.messagedetails.Find(id);
            if (messagedetail == null)
            {
                return HttpNotFound();
            }
            return View(messagedetail);
        }

        // POST: messagedetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,body,title,fa")] messagedetail messagedetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messagedetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(messagedetail);
        }

        // GET: messagedetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            messagedetail messagedetail = db.messagedetails.Find(id);
            if (messagedetail == null)
            {
                return HttpNotFound();
            }
            return View(messagedetail);
        }

        // POST: messagedetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            messagedetail messagedetail = db.messagedetails.Find(id);
            db.messagedetails.Remove(messagedetail);
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
