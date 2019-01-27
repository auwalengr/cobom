using cobom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Highsoft.Web.Mvc.Charts;

namespace cobom.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            ///
            List<double> genetationValues = (from s in db.newarchievementDetails.Where(x => x.name == "generation") select s.amount).ToList();
            List<double> transmissionValues = (from s in db.newarchievementDetails.Where(x => x.name == "transmission") select s.amount).ToList();
            List<double> distributionValues = (from s in db.newarchievementDetails.Where(x => x.name == "distribution") select s.amount).ToList();

            List<BarSeriesData> generationData = new List<BarSeriesData>();
            List<BarSeriesData> transmissionData = new List<BarSeriesData>();
            List<BarSeriesData> distributionData = new List<BarSeriesData>();

            genetationValues.ForEach(p => generationData.Add(new BarSeriesData { Y = p }));
            transmissionValues.ForEach(p => transmissionData.Add(new BarSeriesData { Y = p }));
            distributionValues.ForEach(p => distributionData.Add(new BarSeriesData { Y = p }));

            List<string> category = db.newarchievementDetails.Include(x => x.newarchievement).Where(d => d.newarchievement.type == "Electricity").Select(f => f.date.ToString()).Distinct().ToList();
            
          
            ViewData["generationData"] = generationData;
            ViewData["transmissionData"] = transmissionData;
            ViewData["distributionData"] = distributionData;
            ViewBag.category = category;



            ///
            ViewBag.message = db.messagedetails.OrderBy(x=>x.id);
            ViewBag.news = db.News.OrderByDescending(x => x.id).Take(2).ToList();
            ViewBag.archiement = db.archievements.OrderByDescending(x => x.id).ToList();
            return View(db.slides.OrderByDescending(x=>x.id).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var abt = db.abouts.SingleOrDefault();
            return View(abt);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult coordinators()
        {
            return View(db.coordinators.OrderBy(x=>x.location).ToList());
        }

       public ActionResult news()
        {
            ViewBag.categories = db.newscategories.OrderBy(x=>x.order).ToList();
            var news = db.News.OrderByDescending(x => x.id).ToList();
            return View(news);
        }

        public ActionResult newsdetails(int id)
        {
            var news = db.News.Find(id);
            return View(news);
        }
        public ActionResult gallery()
        {
            return View(db.gallary_picture.ToList());
        }

        public ActionResult achievements()
        {
            var ac = db.newarchievementDetails.Include(x => x.newarchievement).OrderBy(s=>s.date).ToList();
            string[] datasets = (ac.Select(x => x.name).Distinct()).ToArray();
            string[] label = ((ac.Select(x => x.date.ToString())).Distinct()).ToArray();
            string[] datas1 = (ac.Where(x=>x.name=="generation").OrderByDescending(s=>s.date).Select(x => x.amount.ToString())).ToArray();
            //string[] datas2 = (ac.Where(x => x.name == "Transmission").Select(x => x.amount.ToString())).ToArray();
            // string[] label = { "2014", "2015", "2016", "2017", "2018" };
            //x axis 
            ViewBag.datas1 = datas1;
           // ViewBag.datas1 = datas2;
            ViewBag.datasets = datasets;
            ViewBag.label = label;
            return View(ac);
        }

        public ActionResult downloads()
        {
            return View(db.downloadFiles.ToList());
        }

        [HttpPost]
        public FileResult DownloadFile(int? fileId)
        {

            downloadFile file = db.downloadFiles.ToList().Find(p => p.ID == fileId.Value);
            return File(file.Data, file.ContentType, file.Name);
        }

        public ActionResult scorecard()
        {
            List<PieSeriesData> pieData = new List<PieSeriesData>();

            pieData.Add(new PieSeriesData { Name = "2014", Y = 2 });
            pieData.Add(new PieSeriesData { Name = "2016", Y = 5 });
            pieData.Add(new PieSeriesData { Name = "2018", Y = 10, Sliced = true, Selected = true });
            ViewData["pieData"] = pieData;

            return View();
        }

        public ActionResult highchart()
        {
          //  var ac = db.newarchievementDetails.Include(x => x.newarchievement).ToList();
            
            List<double> genetationValues = (from s in db.newarchievementDetails.Where(x => x.name == "generation") select s.amount).ToList();
            List<double> transmissionValues = (from s in db.newarchievementDetails.Where(x => x.name == "transmission") select s.amount).ToList();
            List<double> distributionValues = (from s in db.newarchievementDetails.Where(x => x.name == "distribution") select s.amount).ToList();

            List<BarSeriesData> generationData = new List<BarSeriesData>();
            List<BarSeriesData> transmissionData = new List<BarSeriesData>();
            List<BarSeriesData> distributionData = new List<BarSeriesData>();

            genetationValues.ForEach(p => generationData.Add(new BarSeriesData { Y = p }));
            transmissionValues.ForEach(p => transmissionData.Add(new BarSeriesData { Y = p }));
            distributionValues.ForEach(p => distributionData.Add(new BarSeriesData { Y = p }));

            List<string> category = db.newarchievementDetails.Include(x => x.newarchievement).Where(d => d.newarchievement.type == "Electricity").Select(f => f.date.ToString()).Distinct().ToList();

            ViewData["generationData"] = generationData;
            ViewData["transmissionData"] = transmissionData;
            ViewData["distributionData"] = distributionData;
            ViewBag.category = category;

            return View();
        }


    }
}