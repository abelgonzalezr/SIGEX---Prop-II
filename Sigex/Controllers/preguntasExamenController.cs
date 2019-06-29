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
    public class preguntasExamenController : Controller
    {
        private sigexdbEntities db = new sigexdbEntities();

        // GET: preguntasExamen
        public ActionResult Index()
        {
            var preguntasExamen = db.preguntasExamen.Include(p => p.Examan).Include(p => p.TipoPregunta);
            return View(preguntasExamen.ToList());
        }

        // GET: preguntasExamen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            preguntasExaman preguntasExaman = db.preguntasExamen.Find(id);
            if (preguntasExaman == null)
            {
                return HttpNotFound();
            }
            return View(preguntasExaman);
        }

        // GET: preguntasExamen/Create
        public ActionResult Create()
        {
            ViewBag.idTest = new SelectList(db.Examen, "IdTest", "Nombre");
            ViewBag.idTipoPregunta = new SelectList(db.TipoPreguntas, "IdTipoPregunta", "Nombre");
            return View();
        }

        // POST: preguntasExamen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idpreguntasExamen,idTest,Nombre,Valor,Descripcion,status,idTipoPregunta,RespuestaCorrecta")] preguntasExaman preguntasExaman)
        {
            if (ModelState.IsValid)
            {
                db.preguntasExamen.Add(preguntasExaman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTest = new SelectList(db.Examen, "IdTest", "Nombre", preguntasExaman.idTest);
            ViewBag.idTipoPregunta = new SelectList(db.TipoPreguntas, "IdTipoPregunta", "Nombre", preguntasExaman.idTipoPregunta);
            return View(preguntasExaman);
        }

        // GET: preguntasExamen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            preguntasExaman preguntasExaman = db.preguntasExamen.Find(id);
            if (preguntasExaman == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTest = new SelectList(db.Examen, "IdTest", "Nombre", preguntasExaman.idTest);
            ViewBag.idTipoPregunta = new SelectList(db.TipoPreguntas, "IdTipoPregunta", "Nombre", preguntasExaman.idTipoPregunta);
            return View(preguntasExaman);
        }

        // POST: preguntasExamen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idpreguntasExamen,idTest,Nombre,Valor,Descripcion,status,idTipoPregunta,RespuestaCorrecta")] preguntasExaman preguntasExaman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preguntasExaman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTest = new SelectList(db.Examen, "IdTest", "Nombre", preguntasExaman.idTest);
            ViewBag.idTipoPregunta = new SelectList(db.TipoPreguntas, "IdTipoPregunta", "Nombre", preguntasExaman.idTipoPregunta);
            return View(preguntasExaman);
        }

        // GET: preguntasExamen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            preguntasExaman preguntasExaman = db.preguntasExamen.Find(id);
            if (preguntasExaman == null)
            {
                return HttpNotFound();
            }
            return View(preguntasExaman);
        }

        // POST: preguntasExamen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            preguntasExaman preguntasExaman = db.preguntasExamen.Find(id);
            db.preguntasExamen.Remove(preguntasExaman);
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
