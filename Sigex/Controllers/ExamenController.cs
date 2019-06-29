using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sigex.Data;

namespace Sigex.Controllers
{
    public class ExamenController : Controller
    {
        private sigexdbEntities db = new sigexdbEntities();

        // GET: Examen
        public ActionResult Index()
        {
            return View(db.Examen.ToList());
        }

        // GET: Examen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examan examan = db.Examen.Find(id);
            if (examan == null)
            {
                return HttpNotFound();
            }
            return View(examan);
        }

        // GET: Examen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Examen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTest,Nombre,Fecha,Descripcion,status")] Examan examan)
        {
            if (ModelState.IsValid)
            {
                db.Examen.Add(examan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(examan);
        }

        // GET: Examen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examan examan = db.Examen.Find(id);
            if (examan == null)
            {
                return HttpNotFound();
            }
            return View(examan);
        }

        // POST: Examen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTest,Nombre,Fecha,Descripcion,status")] Examan examan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(examan);
        }

        // GET: Examen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examan examan = db.Examen.Find(id);
            if (examan == null)
            {
                return HttpNotFound();
            }
            return View(examan);
        }

        // POST: Examen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Examan examan = db.Examen.Find(id);
            db.Examen.Remove(examan);
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
