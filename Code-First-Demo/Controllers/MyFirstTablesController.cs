using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Code_First_Demo.Models;
using Code_First_Demo.Repository;

namespace Code_First_Demo.Controllers
{
    public class MyFirstTablesController : Controller
    {
        private CDBContext db = new CDBContext();

        // GET: MyFirstTables
        public ActionResult Index()
        {
            return View(db.MyFirstTable.ToList());
        }

        // GET: MyFirstTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyFirstTable myFirstTable = db.MyFirstTable.Find(id);
            if (myFirstTable == null)
            {
                return HttpNotFound();
            }
            return View(myFirstTable);
        }

        // GET: MyFirstTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyFirstTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Age")] MyFirstTable myFirstTable)
        {
            if (ModelState.IsValid)
            {
                db.MyFirstTable.Add(myFirstTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myFirstTable);
        }

        // GET: MyFirstTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyFirstTable myFirstTable = db.MyFirstTable.Find(id);
            if (myFirstTable == null)
            {
                return HttpNotFound();
            }
            return View(myFirstTable);
        }

        // POST: MyFirstTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Age")] MyFirstTable myFirstTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myFirstTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myFirstTable);
        }

        // GET: MyFirstTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyFirstTable myFirstTable = db.MyFirstTable.Find(id);
            if (myFirstTable == null)
            {
                return HttpNotFound();
            }
            return View(myFirstTable);
        }

        // POST: MyFirstTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyFirstTable myFirstTable = db.MyFirstTable.Find(id);
            db.MyFirstTable.Remove(myFirstTable);
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
