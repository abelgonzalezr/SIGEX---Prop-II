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
    public class TipoPreguntasController : Controller
    {
        private sigexdbEntities db = new sigexdbEntities();

        // GET: TipoPreguntas
        public ActionResult Index()
        {
            return View(db.TipoPreguntas.ToList());
        }

        // GET: TipoPreguntas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPregunta tipoPregunta = db.TipoPreguntas.Find(id);
            if (tipoPregunta == null)
            {
                return HttpNotFound();
            }
            return View(tipoPregunta);
        }

        // GET: TipoPreguntas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPreguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoPregunta,Nombre,status")] TipoPregunta tipoPregunta)
        {
            if (ModelState.IsValid)
            {
                db.TipoPreguntas.Add(tipoPregunta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPregunta);
        }

        // GET: TipoPreguntas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPregunta tipoPregunta = db.TipoPreguntas.Find(id);
            if (tipoPregunta == null)
            {
                return HttpNotFound();
            }
            return View(tipoPregunta);
        }

        // POST: TipoPreguntas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoPregunta,Nombre,status")] TipoPregunta tipoPregunta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPregunta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoPregunta);
        }

        // GET: TipoPreguntas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPregunta tipoPregunta = db.TipoPreguntas.Find(id);
            if (tipoPregunta == null)
            {
                return HttpNotFound();
            }
            return View(tipoPregunta);
        }

        // POST: TipoPreguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPregunta tipoPregunta = db.TipoPreguntas.Find(id);
            db.TipoPreguntas.Remove(tipoPregunta);
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
