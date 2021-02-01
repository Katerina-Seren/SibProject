using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SibProject.Models;

namespace SibProject.Controllers
{
    public class TASKsController : Controller
    {
        private SIBERSPROJECTSEntities db = new SIBERSPROJECTSEntities();


        public ActionResult Index(string SearchString, string PrioritySearch)
        {
            var tASK = db.TASK.Include(t => t.EMPLOYEE).Include(t => t.EMPLOYEE1).Include(t => t.PROJECT).Include(t => t.STATUS);
            if (!String.IsNullOrEmpty(SearchString))
            {
                tASK = tASK.Where(s => s.Name.Contains(SearchString)); // поиск по названию
            }
            if (!String.IsNullOrEmpty(PrioritySearch))
            {
                tASK = tASK.Where(s => s.Priority.ToString().Contains(PrioritySearch)); // поиск по приоритету
            }
            ViewBag.FltrName = SearchString;
            ViewBag.FltrPriority = new SelectList(new string[] { " ", "5", "4", "3", "2", "1" }, PrioritySearch);
            return View(tASK.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TASK tASK = db.TASK.Find(id);
            if (tASK == null)
            {
                return HttpNotFound();
            }
            return View(tASK);
        }


        public ActionResult Create()
        {
            // выбираем из базы фамилию + имя работника и его ID и только работающих с isActive=1
            ViewBag.Author = new SelectList(db.EMPLOYEE.Where(o => o.IsActive == 1).Select(s => new { ID = s.ID, Name = s.SurName + " " + s.FirstName }), "ID", "Name");
            ViewBag.Executor = new SelectList(db.EMPLOYEE.Where(o => o.IsActive == 1).Select(s => new { ID = s.ID, Name = s.SurName + " " + s.FirstName }), "ID", "Name");
            ViewBag.ProjectID = new SelectList(db.PROJECT, "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Author,Executor,StatusID,Priority,ProjectID,Comment")] TASK tASK)
        {


            if (ModelState.IsValid)
            {
                tASK.StatusID = 1;
                db.TASK.Add(tASK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // выбираем из базы фамилию + имя работника и его ID и только работающих с isActive=1
            ViewBag.Author = new SelectList(db.EMPLOYEE.Where(o => o.IsActive == 1).Select(s => new { ID = s.ID, Name = s.SurName + " " + s.FirstName }), "ID", "Name", tASK.Author);
            ViewBag.Executor = new SelectList(db.EMPLOYEE.Where(o => o.IsActive == 1).Select(s => new { ID = s.ID, Name = s.SurName + " " + s.FirstName }), "ID", "Name", tASK.Executor);
            ViewBag.ProjectID = new SelectList(db.PROJECT, "ID", "Name", tASK.ProjectID);
            ViewBag.StatusID = new SelectList(db.STATUS, "ID", "Name", tASK.StatusID);
            return View(tASK);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TASK tASK = db.TASK.Find(id);
            if (tASK == null)
            {
                return HttpNotFound();
            }
            // выбираем из базы фамилию + имя работника и его ID и только работающих с isActive=1
            ViewBag.Author = new SelectList(db.EMPLOYEE.Where(o => o.IsActive == 1).Select(s => new { ID = s.ID, Name = s.SurName + " " + s.FirstName }), "ID", "Name", tASK.Author);
            ViewBag.Executor = new SelectList(db.EMPLOYEE.Where(o => o.IsActive == 1).Select(s => new { ID = s.ID, Name = s.SurName + " " + s.FirstName }), "ID", "Name", tASK.Executor);
            ViewBag.ProjectID = new SelectList(db.PROJECT, "ID", "Name", tASK.ProjectID);
            ViewBag.StatusID = new SelectList(db.STATUS, "ID", "Name", tASK.StatusID);
            return View(tASK);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Author,Executor,StatusID,Priority,ProjectID,Comment")] TASK tASK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tASK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // выбираем из базы фамилию + имя работника и его ID и только работающих с isActive=1
            ViewBag.Author = new SelectList(db.EMPLOYEE.Where(o => o.IsActive == 1).Select(s => new { ID = s.ID, Name = s.SurName + " " + s.FirstName }), "ID", "Name", tASK.Author);
            ViewBag.Executor = new SelectList(db.EMPLOYEE.Where(o => o.IsActive == 1).Select(s => new { ID = s.ID, Name = s.SurName + " " + s.FirstName }), "ID", "Name", tASK.Executor);
            ViewBag.ProjectID = new SelectList(db.PROJECT, "ID", "Name", tASK.ProjectID);
            ViewBag.StatusID = new SelectList(db.STATUS, "ID", "Name", tASK.StatusID);
            return View(tASK);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TASK tASK = db.TASK.Find(id);
            if (tASK == null)
            {
                return HttpNotFound();
            }
            return View(tASK);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TASK tASK = db.TASK.Find(id);
            db.TASK.Remove(tASK);
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