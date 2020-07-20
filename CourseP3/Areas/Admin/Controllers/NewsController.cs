using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseP3.Models;
using PagedList;

namespace CourseP3.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/News
        public ActionResult Index(string sortOrder, string searchString, int? page, int? pageSize, string listnews)
        {
            var news = db.News.Where(x => x.Status == 1);

            if (!String.IsNullOrEmpty(searchString))
            {
                news = db.News.Where(x => x.Title.Contains(searchString))
                    .Where(x => x.Status == 1);
            }

            ViewBag.PageSize = new List<SelectListItem>()
            {
                new SelectListItem() { Text="5", Value= "5"},
                new SelectListItem() { Text="10", Value= "10"},
                new SelectListItem() { Text="15", Value= "15" },
                new SelectListItem() { Text="20", Value= "20" },
            };
            ViewBag.listnews = new List<SelectListItem>()
            {
                new SelectListItem() { Text="List", Value= "0" },
                new SelectListItem() { Text="Delete", Value= "-1"},
            };
            switch (listnews)
            {
                case "0":
                    news = db.News.Where(x => x.Status == 1);
                    break;
                case "-1":
                    news = db.News.Where(x => x.Status == -1);
                    break;
            }
            int pagesize = (pageSize ?? 5);
            int pageNumber = (page ?? 1);
            ViewBag.psize = pagesize;

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "Price_desc" : "Price";
            switch (sortOrder)
            {
                case "Name_desc":
                    news = news.OrderByDescending(s => s.Title);
                    break;
               
                default:
                    news = news.OrderBy(s => s.Title);
                    break;
            }
            return View(news.ToList().ToPagedList(pageNumber, pagesize));
        }

        // GET: Admin/News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: Admin/News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                var newsCreate = new News()
                {
                    Title = news.Title,
                    Description = news.Description,
                    Status = 1
                
                };
                db.News.Add(newsCreate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Admin/News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: Admin/News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Status")] News news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

  
        // POST: Admin/News/Delete/5
        [HttpPost]
        public ActionResult ChangeStatus(int action, int[] selectedIDs)
        {
            foreach (int IDs in selectedIDs)
            {
                News news = db.News.Find(IDs);
                db.News.Attach(news);
                news.Status = action;
            }
            db.SaveChanges();
            return Json(selectedIDs, JsonRequestBehavior.AllowGet);
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
