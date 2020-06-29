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
    public class StudentCoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/StudentCourses
     
        public ActionResult Index( int? page, int? pageSize, string listStudentcourse)
        {
            var studentCourses = db.StudentCourses.Include(s => s.Course).Include(s => s.Student);


          

            ViewBag.PageSize = new List<SelectListItem>()
            {
                new SelectListItem() { Text="5", Value= "5"},
                new SelectListItem() { Text="10", Value= "10"},
                new SelectListItem() { Text="15", Value= "15" },
                new SelectListItem() { Text="20", Value= "20" },
            };
            ViewBag.listStudentcourse = new List<SelectListItem>()
            {
                new SelectListItem() { Text="Completed", Value= "1"},
                new SelectListItem() { Text="Learning", Value= "0" },
                new SelectListItem() { Text="Delete", Value= "-1"},
                new SelectListItem() { Text="Active", Value= "2"},
                
            };
            switch (listStudentcourse)
            {
                case "1":
                    studentCourses = db.StudentCourses.Include(s => s.Course).Include(s => s.Student).Where(x => x.Status == 1);
                    break;
                case "-1":
                    studentCourses = db.StudentCourses.Include(s => s.Course).Include(s => s.Student).Where(x => x.Status == -1);
                    break;
                case "0":
                    studentCourses = db.StudentCourses.Include(s => s.Course).Include(s => s.Student).Where(x => x.Status == 0);
                    break;
                case "2":
                    studentCourses = db.StudentCourses.Include(s => s.Course).Include(s => s.Student).Where(x => x.Status == 2);
                    break;
            }
            int pagesize = (pageSize ?? 5);
            int pageNumber = (page ?? 1);
            ViewBag.psize = pagesize;
          
           
            return View(studentCourses.ToList().ToPagedList(pageNumber, pagesize));
        }


        // GET: Admin/StudentCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourse studentCourse = db.StudentCourses.Find(id);
            if (studentCourse == null)
            {
                return HttpNotFound();
            }
            return View(studentCourse);
        }

        // GET: Admin/StudentCourses/Create
        [HttpPost]
        public ActionResult ChangeStatus(int action, int[] selectedIDs)
        {
            foreach (int IDs in selectedIDs)
            {
                StudentCourse studentCourse = db.StudentCourses.Find(IDs);
                db.StudentCourses.Attach(studentCourse);
                studentCourse.Status = action;
               
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
