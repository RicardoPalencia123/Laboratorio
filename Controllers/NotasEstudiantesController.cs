using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using rickar;

namespace rickar.Controllers
{
    public class NotasEstudiantesController : Controller
    {
        private NotasRickarEntities db = new NotasRickarEntities();

      
        public ActionResult Index()
        {
            return View(db.NotasEstudiante.ToList());
        }

    
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotasEstudiante notasEstudiante = db.NotasEstudiante.Find(id);
            if (notasEstudiante == null)
            {
                return HttpNotFound();
            }
            return View(notasEstudiante);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdNota,Nombre,Labouno,Labodos,Labotres,parcialuno,parcialdos,parcialtres")] NotasEstudiante notasEstudiante)
        {
            if (ModelState.IsValid)
            {
                db.NotasEstudiante.Add(notasEstudiante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notasEstudiante);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotasEstudiante notasEstudiante = db.NotasEstudiante.Find(id);
            if (notasEstudiante == null)
            {
                return HttpNotFound();
            }
            return View(notasEstudiante);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdNota,Nombre,Labouno,Labodos,Labotres,parcialuno,parcialdos,parcialtres")] NotasEstudiante notasEstudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notasEstudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notasEstudiante);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotasEstudiante notasEstudiante = db.NotasEstudiante.Find(id);
            if (notasEstudiante == null)
            {
                return HttpNotFound();
            }
            return View(notasEstudiante);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NotasEstudiante notasEstudiante = db.NotasEstudiante.Find(id);
            db.NotasEstudiante.Remove(notasEstudiante);
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
