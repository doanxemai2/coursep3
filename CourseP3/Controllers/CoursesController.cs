using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseP3.Areas.Admin.Models;
using CourseP3.Models;
using Microsoft.AspNet.Identity;
using PagedList;

namespace CourseP3.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Courses
        public ActionResult Index(int? page, int? pageSize, string currentFilter, string searchString, string listCourse)
        {
            var Semester = db.Semesters.ToList();
            ViewBag.Semes = Semester;
            var course = db.Courses.Where(x=>x.Status!=-1);
            if (searchString == null)
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                course = db.Courses.Where(s => s.Name.Contains(searchString)
                                       );
            }
            if (!String.IsNullOrEmpty(listCourse))
            {

                switch (listCourse)
                {
                    case "All":
                        course = db.Courses.Where(x => x.Status != -1);
                        break;
                    case "1":
                        course = db.Courses.Where(x => x.SemesterId == 1).Where(x => x.Status != -1);
                        break;
                    case "2":
                        course = db.Courses.Where(x => x.SemesterId == 2).Where(x => x.Status != -1);
                        break;
                    case "3":
                        course = db.Courses.Where(x => x.SemesterId == 3).Where(x => x.Status != -1);
                        break;
                    case "4":
                        course = db.Courses.Where(x => x.SemesterId == 4).Where(x => x.Status != -1);
                        break;


                }
                ViewBag.Currentlistcourse = listCourse;
            }
          
            int pagesize = (pageSize ?? 6);
            int pageNumber = (page ?? 1);
            ViewBag.psize = pagesize;
            return View(course.ToList().ToPagedList(pageNumber, pagesize));
        }
        public ActionResult Add(int id)
        {
            string curentuserid = User.Identity.GetUserId();
            StudentCourse studentCourse = new StudentCourse();
            studentCourse.CourseId = id;
            studentCourse.StudentId = curentuserid;
            studentCourse.Status = 2;
            var sc = db.StudentCourses.Where(r => r.CourseId == id && r.StudentId == curentuserid).ToList();
            var Cs = db.Courses.Find(id);
            var idSm = Cs.SemesterId;
            var idSmUser = db.Users.Find(curentuserid).Id;
            if (sc.Count == 0 && idSm.Equals(idSmUser))
            {
                db.StudentCourses.Add(studentCourse);
                db.SaveChanges();
                TempData["succers"] = "Save Course Success!!!";
            }
            else
            {
                TempData["err"] = "You have already signed up for the course or Your course is incorrect!!!";
            }
            //return RedirectToAction("Index", "Home");
            return RedirectToAction("Student", "Home");

        }

        public ActionResult Detail(int? id)
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
    }
}