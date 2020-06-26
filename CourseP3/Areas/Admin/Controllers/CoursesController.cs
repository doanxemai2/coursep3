using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseP3.Areas.Admin.Models;
using CourseP3.Models;
using PagedList;

namespace CourseP3.Areas.Admin.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Courses
        public ActionResult Index(string sortOrder, string searchString, int? page, int? pageSize, string listcourse)
        {
            var courses = db.Courses.Where(x => x.Status == 1);

            if (!String.IsNullOrEmpty(searchString))
            {
                courses = db.Courses.Where(x => x.Title.Contains(searchString))
                    .Where(x => x.Status == 1);
            }

            ViewBag.PageSize = new List<SelectListItem>()
            {
                new SelectListItem() { Text="5", Value= "5"},
                new SelectListItem() { Text="10", Value= "10"},
                new SelectListItem() { Text="15", Value= "15" },
                new SelectListItem() { Text="20", Value= "20" },
            };
            ViewBag.listcourse = new List<SelectListItem>()
            {
                new SelectListItem() { Text="List", Value= "0" },
                new SelectListItem() { Text="Delete", Value= "-1"},
            };
            switch (listcourse)
            {
                case "0":
                    courses = db.Courses.Where(x => x.Status == 1);
                    break;
                case "-1":
                    courses = db.Courses.Where(x => x.Status == -1);
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
                    courses = courses.OrderByDescending(s => s.Title);
                    break;

                default:
                    courses = courses.OrderBy(s => s.Title);
                    break;
            }
            return View(courses.ToList().ToPagedList(pageNumber, pagesize));
        }
        // POST: Admin/News/Delete/5
        [HttpPost]
        public ActionResult ChangeStatus(int action, int[] selectedIDs)
        {
            foreach (int IDs in selectedIDs)
            {
                Course course = db.Courses.Find(IDs);
                db.Courses.Attach(course);
                course.Status = action;
            }
            db.SaveChanges();
            return Json(selectedIDs, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Admin/Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Title,Time,Description,Image,Price,Status")] Course course)
        {
            if (ModelState.IsValid)
            {
                var courses = new Course()
                {
                    Name = course.Name,
                    Title = course.Title,
                    Time = course.Time,
                    Description = course.Description,
                    Image = course.Image,
                    Price = course.Price,
                    Status = 1,
                };
                db.Courses.Add(courses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Admin/Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Admin/Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Title,Time,Description,Image,Price,Status")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
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
