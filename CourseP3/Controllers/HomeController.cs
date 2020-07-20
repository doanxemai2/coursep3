using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseP3.Areas.Admin.Models;
using CourseP3.Models;
using Microsoft.AspNet.Identity;

namespace CourseP3.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Courses = db.Courses.Where(x=>x.Status!=-1).ToList();
            return View();
        }

        [ChildActionOnly]
        public ActionResult NavBar()
        {
            return PartialView("~/Views/Shared/_Navbar.cshtml", db.CenterDetails.ToList().FirstOrDefault());
        }

        public ActionResult About()
        {

            return View();
        }
        [Authorize(Roles = "Student")]
        public ActionResult Student()
        {
            string curentuserid = User.Identity.GetUserId();
            var Sc = db.StudentCourses.Where(r => r.StudentId == curentuserid && r.Course.SemesterId == 1).ToList();
            var sm2 = db.StudentCourses.Where(r => r.StudentId == curentuserid && r.Course.SemesterId == 2).ToList();
            var sm3 = db.StudentCourses.Where(r => r.StudentId == curentuserid && r.Course.SemesterId == 3).ToList();
            var sm4 = db.StudentCourses.Where(r => r.StudentId == curentuserid && r.Course.SemesterId == 4).ToList();
            ApplicationUser st = db.Users.FirstOrDefault(x => x.Id == curentuserid);
            Semester semester = db.Semesters.FirstOrDefault(r => r.Id == st.SemesterId);
            ViewBag.stNamee = st.UserName;
            ViewBag.CurrentUser = st;
            ViewBag.sm2 = sm2;
            ViewBag.sm3 = sm3;
            ViewBag.sm4 = sm4;
            ViewBag.stSemester = semester.Name;
            return View(Sc);
        }
        public ActionResult Contact()
        {
            return View();
        }
        [Authorize]
        public ActionResult Add(int id)
        {

            string curentuserid = User.Identity.GetUserId();
            StudentCourse studentCourse = new StudentCourse();
            studentCourse.CourseId = id;
            studentCourse.StudentId = curentuserid;

            studentCourse.Status = 1;
            var sc = db.StudentCourses.Where(r => r.CourseId == id && r.StudentId == curentuserid).ToList();
            var Cs = db.Courses.Find(id);
            var idSm = Cs.SemesterId;
            var idSmUser = db.Users.Find(curentuserid).SemesterId;
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
        public ActionResult FAQ()
        {
            return View(db.FAQs.ToList());
        }
        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        public ActionResult News()
        {
            return View(db.News.ToList());
        }
        public ActionResult NewsDetails(int? id)
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

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Student")]
        public ActionResult Question(int CourseId)
        {
            var list = db.Question.Include(x => x.Choices).Where(x => x.CourseId == CourseId).ToList();
            //var id = User.Identity.GetUserId();
            //var studentCourse = db.StudentCourses.Where(x => x.StudentId == id).FirstOrDefault(x => x.CourseId == courseId);
            //if (studentCourse != null)
            //{
            //    studentCourse.Status = (int)StudentCourse.StudentCourseStatus.Done;
            //    db.Entry(studentCourse).State = EntityState.Modified;
            //}
            //db.SaveChanges();
            return View(list);
        }
        [HttpPost]
        [Authorize(Roles = "Student")]
        public ActionResult Test(List<Question> resultQuiz)
        {
            
            int totalPointTest = 0;
            int totalPoint = 0;
            int answer = 0;
            int courseId = 0;
            foreach (var item in resultQuiz)
            {
                var question = db.Question.Find(item.Id);
                courseId = question.CourseId;
                totalPointTest += question.Point;

                if (item.AnswerContent != null)
                {
                    if (item.AnswerContent.Equals(question.AnswerContent))
                    {
                        totalPoint += question.Point;
                        answer += 1;
                    }
                }
            }

            double result = (double)totalPoint / totalPointTest * 100;
            int percent = (int) Math.Round(result, 0);
            Session["pointEx"] = percent;           
            return Json(new
            {
                point = percent,
                answerRight = answer,
                courseId = courseId
            }, JsonRequestBehavior.AllowGet);
        }
        [Authorize(Roles = "Student")]
        public ActionResult Result(int courseId, int answerRight)
        {
            var id = User.Identity.GetUserId();
            ViewBag.Student = db.Users.Find(id);
            ViewBag.Course = db.Courses.Find(courseId);
            ViewBag.AnswerRight = answerRight;
            int pointEx = (int) Session["pointEx"];
            var studentCourse = db.StudentCourses.Where(x => x.StudentId == id).FirstOrDefault(x => x.CourseId == courseId);
            if (studentCourse != null)
            {
                studentCourse.PointEx = pointEx;
                db.Entry(studentCourse).State = EntityState.Modified;
            }

            db.SaveChanges();
            return View();
        }
    }
}
