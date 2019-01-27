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
    public class newsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: news
        public ActionResult Index()
        {
            return View(db.News.ToList());
        }

        // GET: news/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            news news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: news/Create
        public ActionResult Create()
        {
            ViewBag.newscategoryid = new SelectList(db.newscategories, "id", "category");
            return View();
        }

        // POST: news/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,body, newscategoryid,datetime")] news news, HttpPostedFileBase imgurl)
        {
            if (ModelState.IsValid)
            {
                
                if (imgurl != null)
                {
                    news.imgurl = imgurl.FileName;
                    string path = Path.Combine(Server.MapPath("~/images/news"), Path.GetFileName(imgurl.FileName));
                    imgurl.SaveAs(path);
                }
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(news);
        }

        // GET: news/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            news news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.newscategoryid = new SelectList(db.newscategories, "id", "category");
            return View(news);
        }

        // POST: news/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,body, newscategoryid,datetime,imgurl")] news news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: news/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            news news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: news/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            news news = db.News.Find(id);
            db.News.Remove(news);
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
