using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CourseP3.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace CourseP3.Areas.Admin.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public StudentsController()
        {
        }

        public StudentsController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult GetListStudentData()
        {
            var role = db.Roles.Where(x => x.Name == "Student").FirstOrDefault();
            var students = db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id)).ToList();
            return new JsonResult()
            {
                Data = students.Select(x => new
                {
                    FullName = x.Fullname,
                    Email = x.Email
                }),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        // GET: Admin/Students
        public ActionResult Index(string email)
        {
            var role = db.Roles.Where(x => x.Name == "Student").FirstOrDefault();
            var students = db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id)).ToList();
            if (!String.IsNullOrEmpty(email))
            {
                students = students.Where(x => x.Email == email).ToList();
                return View(students);
            }
            
            return View(students);
        }

        public ActionResult Details(string id, int? sem)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            var semester = db.Semesters.Where(x => x.Id <= user.SemesterId).ToList();
            ViewBag.semmesters = semester;

            if (sem != null) {
                  var studentCourses = db.StudentCourses.Include(s => s.Course).Include(s => s.Student).Where(s=>s.Student.Id.Equals(user.Id)).Where(s=>s.Course.SemesterId==sem).Where(x=>x.Status!=-1).ToList();
                ViewBag.studentCourses = studentCourses;

            }
            return View(user);
        }
        [HttpPost]
        public ActionResult ChangePoint(int id, int value)
        {
                StudentCourse studentCourse = db.StudentCourses.Find(id);
                db.StudentCourses.Attach(studentCourse);
            studentCourse.Point = value;
            studentCourse.Status = 1;
            db.SaveChanges();
            return Json(id, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            ViewBag.SemesterId = new SelectList(db.Semesters, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Email,Phone,Fullname, Address, SemesterId")] Student model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Phone = model.Phone, Fullname = model.Fullname, Address = model.Address, SemesterId = model.SemesterId};
                var result = await UserManager.CreateAsync(user, "password");
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    UserManager.AddToRole(user.Id, "Student");
                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser student  = db.Users.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.SemesterId = new SelectList(db.Semesters, "Id", "Name", student.SemesterId);
            return View(student);
        }

        // POST: Admin/Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Phone,Fullname,Address,SemesterId")] ApplicationUser model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Find(model.Id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                user.Fullname = model.Fullname;
                user.Address = model.Address;
                user.Phone = model.Phone;
                user.SemesterId = model.SemesterId;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApplicationUser user = db.Users.Find(id);
            //db.Users.Remove(user);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
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