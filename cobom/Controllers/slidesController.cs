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
using System.Web.Hosting;

namespace cobom.Controllers
{
    [Authorize]
    public class slidesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: slides
        public ActionResult Index()
        {
            return View(db.slides.ToList());
        }

        // GET: slides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            slide slide = db.slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // GET: slides/Create
        public ActionResult Create()
        {
            ViewBag.news = db.News.ToList();
            ViewBag.achiement = db.archievements.ToList();
            ViewBag.download = db.downloadFiles.ToList();
            return View();
        }

        // POST: slides/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,body,url")] slide slide, HttpPostedFileBase imgurl)
        {
            if (ModelState.IsValid)
            {
                
              
                if (imgurl != null)
                {
                    slide.imgurl = imgurl.FileName;
                    string path = Path.Combine(Server.MapPath("~/images"), Path.GetFileName(imgurl.FileName));
                    imgurl.SaveAs(path);
                }
                db.slides.Add(slide);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slide);
        }

        // GET: slides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            slide slide = db.slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // POST: slides/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,body,imgurl,url")] slide slide)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slide).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slide);
        }

        // GET: slides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            slide slide = db.slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // POST: slides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            slide slide = db.slides.Find(id);
            string path = "images/" + slide.imgurl;
           // if(DeleteFile(path) == true)
           // {
                db.slides.Remove(slide);
                db.SaveChanges();
           // }
           
            return RedirectToAction("Index");
        }

        //private bool DeleteFile(string image1_Address = "")
        //{
        //    try
        //    {
        //        if (image1_Address != null && image1_Address.Length > 0)
        //        {
        //            string fullPath = Server.MapPath("~" + image1_Address);
        //            if (System.IO.File.Exists(fullPath))
        //            {
        //                System.IO.File.Delete(fullPath);
        //                return true;
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    { }
        //    return false;
        //}
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
