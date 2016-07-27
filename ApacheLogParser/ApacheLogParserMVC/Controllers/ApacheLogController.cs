using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApacheLogParser;

namespace ApacheLogParserMVC.Controllers
{
    public class ApacheLogController : Controller
    {
        private ApacheLogContext db = new ApacheLogContext();

        // GET: ApacheLog
        public ActionResult Index()
        {
            var logEntries = db.LogEntries.Include(a => a.File).Include(a => a.IpAddress);
            return View(logEntries.ToList());
        }

        // GET: ApacheLog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApacheLogEntry apacheLogEntry = db.LogEntries.Find(id);
            if (apacheLogEntry == null)
            {
                return HttpNotFound();
            }
            return View(apacheLogEntry);
        }

        // GET: ApacheLog/Create
        public ActionResult Create()
        {
            ViewBag.FileId = new SelectList(db.Files, "Id", "FullName");
            ViewBag.IpAddressId = new SelectList(db.IpAddresses, "Id", "OwnerCompany");
            return View();
        }

        // POST: ApacheLog/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,QueryType,QueryResult,FileId,DataSize,IpAddressId")] ApacheLogEntry apacheLogEntry)
        {
            if (ModelState.IsValid)
            {
                db.LogEntries.Add(apacheLogEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FileId = new SelectList(db.Files, "Id", "FullName", apacheLogEntry.FileId);
            ViewBag.IpAddressId = new SelectList(db.IpAddresses, "Id", "OwnerCompany", apacheLogEntry.IpAddressId);
            return View(apacheLogEntry);
        }

        // GET: ApacheLog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApacheLogEntry apacheLogEntry = db.LogEntries.Find(id);
            if (apacheLogEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.FileId = new SelectList(db.Files, "Id", "FullName", apacheLogEntry.FileId);
            ViewBag.IpAddressId = new SelectList(db.IpAddresses, "Id", "OwnerCompany", apacheLogEntry.IpAddressId);
            return View(apacheLogEntry);
        }

        // POST: ApacheLog/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,QueryType,QueryResult,FileId,DataSize,IpAddressId")] ApacheLogEntry apacheLogEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apacheLogEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FileId = new SelectList(db.Files, "Id", "FullName", apacheLogEntry.FileId);
            ViewBag.IpAddressId = new SelectList(db.IpAddresses, "Id", "OwnerCompany", apacheLogEntry.IpAddressId);
            return View(apacheLogEntry);
        }

        // GET: ApacheLog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApacheLogEntry apacheLogEntry = db.LogEntries.Find(id);
            if (apacheLogEntry == null)
            {
                return HttpNotFound();
            }
            return View(apacheLogEntry);
        }

        // POST: ApacheLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApacheLogEntry apacheLogEntry = db.LogEntries.Find(id);
            db.LogEntries.Remove(apacheLogEntry);
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
