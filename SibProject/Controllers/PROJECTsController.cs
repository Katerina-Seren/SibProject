using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SibProject.Models;

namespace SibProject.Controllers
{
    public class PROJECTsController : Controller
    {
        private SIBERSPROJECTSEntities db = new SIBERSPROJECTSEntities();
       
        public ActionResult Index(string SearchString)
        {

            var pROJECT = db.PROJECT.Include(p => p.EMPLOYEE);

            if (!String.IsNullOrEmpty(SearchString))
            {
                pROJECT = pROJECT.Where(s => s.Name.Contains(SearchString)); // поиск по названию
            }
            ViewBag.Fltr = SearchString;
            return View(pROJECT.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJECT pROJECT = db.PROJECT.Find(id);
            if (pROJECT == null)
            {
                return HttpNotFound();
            }
            return View(pROJECT);
        }

        public ActionResult Create()
        {
            // выбираем из базы фамилию + имя работника и его ID и только работающих с isActive=1
            ViewBag.ProjectLeader = new SelectList(db.EMPLOYEE.Where(o => o.IsActive == 1).Select(s => new { ID = s.ID, Name = s.SurName + " " + s.FirstName }), "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Customer,Executor,ProjectLeader,StartDate,ExpirationDate,Priority")] PROJECT pROJECT)
        {

            if (ModelState.IsValid)
            {
                db.PROJECT.Add(pROJECT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // выбираем из базы фамилию + имя работника и его ID и только работающих с isActive=1
            ViewBag.ProjectLeader = new SelectList(db.EMPLOYEE.Where(o => o.IsActive == 1).Select(s => new { ID = s.ID, Name = s.SurName + " " + s.FirstName }), "ID", "Name", pROJECT.ProjectLeader);
            return View(pROJECT);
        }

        [HttpPost]
        public ActionResult UploadFiles(IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                string filePath = Path.GetFileNameWithoutExtension(file.FileName) + Path.GetExtension(file.FileName);
                file.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), filePath));
                
                // Area for table data insert
              //  FILE tbl = new FILE();
              //  tbl.Name = filePath;
              //  tbl.ID_PROJECT = ViewBag 
              //  db.FILE.Add(tbl);
              //  db.SaveChanges();
                

            }
            return Json("file uploaded successfully");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJECT pROJECT = db.PROJECT.Find(id);
            if (pROJECT == null)
            {
                return HttpNotFound();
            }

            // выбираем из базы фамилию + имя работника и его ID и только работающих с isActive=1
            ViewBag.ProjectLeader = new SelectList(db.EMPLOYEE.Where(o => o.IsActive == 1).Select(s => new { ID = s.ID, Name = s.SurName + " " + s.FirstName }), "ID", "Name", pROJECT.ProjectLeader);
            return View(pROJECT);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Customer,Executor,ProjectLeader,StartDate,ExpirationDate,Priority")] PROJECT pROJECT)
        {

            if (ModelState.IsValid)
            {
                db.Entry(pROJECT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // выбираем из базы фамилию + имя работника и его ID и только работающих с isActive=1
            ViewBag.ProjectLeader = new SelectList(db.EMPLOYEE.Where(o => o.IsActive == 1).Select(s => new { ID = s.ID, Name = s.SurName + " " + s.FirstName }), "ID", "Name", pROJECT.ProjectLeader);
            return View(pROJECT);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJECT pROJECT = db.PROJECT.Find(id);
            if (pROJECT == null)
            {
                return HttpNotFound();
            }
            return View(pROJECT);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROJECT pROJECT = db.PROJECT.Find(id);
            db.PROJECT.Remove(pROJECT);
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