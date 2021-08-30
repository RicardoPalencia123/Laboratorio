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

        // GET: NotasEstudiantes
        public ActionResult Index()
        {
            return View(db.NotasEstudiante.ToList());
        }

        // GET: NotasEstudiantes/Details/5
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

        // GET: NotasEstudiantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NotasEstudiantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: NotasEstudiantes/Edit/5
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

        // POST: NotasEstudiantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: NotasEstudiantes/Delete/5
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

        // POST: NotasEstudiantes/Delete/5
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
