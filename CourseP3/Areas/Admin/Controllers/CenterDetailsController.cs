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

namespace CourseP3.Areas.Admin.Controllers
{
    public class CenterDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/CenterDetails
        public ActionResult Index()
        {
            return View(db.CenterDetails.ToList());
        }

        // GET: Admin/CenterDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CenterDetail centerDetail = db.CenterDetails.Find(id);
            if (centerDetail == null)
            {
                return HttpNotFound();
            }
            return View(centerDetail);
        }

        // GET: Admin/CenterDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CenterDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Hotline,Description,Status")] CenterDetail centerDetail)
        {
            if (ModelState.IsValid)
            {
                db.CenterDetails.Add(centerDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centerDetail);
        }

        // GET: Admin/CenterDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CenterDetail centerDetail = db.CenterDetails.Find(id);
            if (centerDetail == null)
            {
                return HttpNotFound();
            }
            return View(centerDetail);
        }

        // POST: Admin/CenterDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Hotline,Description,Status")] CenterDetail centerDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(centerDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centerDetail);
        }

        // GET: Admin/CenterDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CenterDetail centerDetail = db.CenterDetails.Find(id);
            if (centerDetail == null)
            {
                return HttpNotFound();
            }
            return View(centerDetail);
        }

        // POST: Admin/CenterDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CenterDetail centerDetail = db.CenterDetails.Find(id);
            db.CenterDetails.Remove(centerDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
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
