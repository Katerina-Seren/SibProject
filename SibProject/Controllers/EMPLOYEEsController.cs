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
    public class EMPLOYEEsController : Controller
    {
        private SIBERSPROJECTSEntities db = new SIBERSPROJECTSEntities();

        public ActionResult Index(string SearchString)
        {
            var eMPLOYEE = db.EMPLOYEE.Where(o => o.IsActive == 1); // вывод только работающих (isActive = 0 значит работник удален)
            if (!String.IsNullOrEmpty(SearchString))
            {
                eMPLOYEE = eMPLOYEE.Where(s => s.SurName.Contains(SearchString)); // поиск по фамилии
            }
            ViewBag.Fltr = SearchString;
            return View(eMPLOYEE.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEE eMPLOYEE = db.EMPLOYEE.Find(id);
            if (eMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEE);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,SurName,Patronymic,Email,IsActive")] EMPLOYEE eMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                eMPLOYEE.IsActive = 1; // IsActive по умолчанию - 1 для записи в базу (меняем на 0 только в случае удаления работника)
                db.EMPLOYEE.Add(eMPLOYEE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eMPLOYEE);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEE eMPLOYEE = db.EMPLOYEE.Find(id);
            if (eMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEE);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,SurName,Patronymic,Email,IsActive")] EMPLOYEE eMPLOYEE)
        {

            if (ModelState.IsValid)
            {
                db.Entry(eMPLOYEE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eMPLOYEE);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEE eMPLOYEE = db.EMPLOYEE.Find(id);
            if (eMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEE);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPLOYEE eMPLOYEE = db.EMPLOYEE.Find(id);
            eMPLOYEE.IsActive = 0;
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