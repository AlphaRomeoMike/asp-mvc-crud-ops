using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Crud_Application_with_Db_First_Approach;

namespace Crud_Application_with_Db_First_Approach.Controllers
{
    public class StudentsController : Controller
    {
        private MVC_CRUDEntities db = new MVC_CRUDEntities();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.tbl_students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_students tbl_students = db.tbl_students.Find(id);
            if (tbl_students == null)
            {
                return HttpNotFound();
            }
            return View(tbl_students);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Grade,Section")] tbl_students tbl_students)
        {
            if (ModelState.IsValid)
            {
                db.tbl_students.Add(tbl_students);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_students);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_students tbl_students = db.tbl_students.Find(id);
            if (tbl_students == null)
            {
                return HttpNotFound();
            }
            return View(tbl_students);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Grade,Section")] tbl_students tbl_students)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_students);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_students tbl_students = db.tbl_students.Find(id);
            if (tbl_students == null)
            {
                return HttpNotFound();
            }
            return View(tbl_students);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_students tbl_students = db.tbl_students.Find(id);
            db.tbl_students.Remove(tbl_students);
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
