using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseP3.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View("Dashboard");
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
    }
}