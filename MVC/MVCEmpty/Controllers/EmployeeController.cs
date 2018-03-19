using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.Entities;
using Repository.Services;

namespace MVCEmpty.Controllers
{
    public class EmployeeController : Controller
    {
        private NorthwindDbContext db = new NorthwindDbContext();

        // GET: Employee
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeEntity employeeEntity = db.Employees.Find(id);
            if (employeeEntity == null)
            {
                return HttpNotFound();
            }
            return View(employeeEntity);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,FirstName,LastName")] EmployeeEntity employeeEntity)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employeeEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeEntity);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeEntity employeeEntity = db.Employees.Find(id);
            if (employeeEntity == null)
            {
                return HttpNotFound();
            }
            return View(employeeEntity);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,FirstName,LastName")] EmployeeEntity employeeEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeEntity);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeEntity employeeEntity = db.Employees.Find(id);
            if (employeeEntity == null)
            {
                return HttpNotFound();
            }
            return View(employeeEntity);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeEntity employeeEntity = db.Employees.Find(id);
            db.Employees.Remove(employeeEntity);
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
