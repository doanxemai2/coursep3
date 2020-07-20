using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseP3.Models;

namespace CourseP3.Areas.Admin.Controllers
{
    
    public class DashboardController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Home
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Chart()
        {
            return View();
        }
        public ActionResult Table()
        {
            return View();
        }
        public ActionResult Form()
        {
            return View();
        }
        public ActionResult Question()
        {
            var list = db.Question.Include(x => x.Choices).ToList();
            return View(list);
        }
        public ActionResult Test(List<Question> resultQuiz)
        {
            int totalPointTest = 0;
            foreach (var item in db.Question)
            {
                totalPointTest += item.Point;
            }
            int totalPoint = 0;
            foreach (var item in resultQuiz)
            {
                if (item.AnswerContent != null)
                {
                    var question = db.Question.Find(item.Id);
                    if (item.AnswerContent.Equals(question.AnswerContent))
                    {
                        totalPoint += question.Point;
                    }
                }
            }

            double result = (double)totalPoint / totalPointTest * 100;
            double percent = Math.Round(result, 0);
            ViewBag.ResultPercent = percent;
            return Json(new {data = percent}, JsonRequestBehavior.AllowGet);
        }
    }
}