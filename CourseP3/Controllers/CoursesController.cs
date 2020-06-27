﻿using System;
using System.Collections.Generic;
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
    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Courses
        public ActionResult Index()
        {
            var Semester = db.Semesters.ToList();
            ViewBag.Semes = Semester;

            return View(db.Courses.ToList());
        }
        public ActionResult Add(int id)
        {
            string curentuserid = User.Identity.GetUserId();
            StudentCourse studentCourse = new StudentCourse();
            studentCourse.CourseId = id;
            studentCourse.StudentId = curentuserid;
            studentCourse.Status = StudentCourse.StudentCourseStatus.Active;
            var sc = db.StudentCourses.Where(r => r.CourseId == id && r.StudentId == curentuserid).ToList();
            if (sc.Count == 0)
            {
                db.StudentCourses.Add(studentCourse);
                db.SaveChanges();
                ViewBag.Mess = "Save Course Success!!!";
            }
            else
            {
                ViewBag.Mess = "You have already signed up for the course!!!";
            }
            return Redirect("Index"); ;
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