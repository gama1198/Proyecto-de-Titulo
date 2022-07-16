using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tesismvc.Models;

namespace Tesismvc.Controllers
{
    public class AlumnosesController : Controller
    {
        private Sistema_Escolar_respladoEntities db = new Sistema_Escolar_respladoEntities();

        // GET: Alumnoses
        public ActionResult Index()
        {
            var alumnos = db.Alumnos.Include(a => a.Curso);
            return View(alumnos.ToList());
        }

        // GET: Alumnoses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnos alumnos = db.Alumnos.Find(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            return View(alumnos);
        }

        // GET: Alumnoses/Create
        public ActionResult Create()
        {
            ViewBag.idcurso = new SelectList(db.Curso, "id_Curso", "Nombre_Curso");
            return View();
        }

        // POST: Alumnoses/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Alumno,Nombre,Apellido_p,Apellido_m,Direccion,idcurso")] Alumnos alumnos)
        {
            if (ModelState.IsValid)
            {
                db.Alumnos.Add(alumnos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcurso = new SelectList(db.Curso, "id_Curso", "Nombre_Curso", alumnos.idcurso);
            return View(alumnos);
        }

        // GET: Alumnoses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnos alumnos = db.Alumnos.Find(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcurso = new SelectList(db.Curso, "id_Curso", "Nombre_Curso", alumnos.idcurso);
            return View(alumnos);
        }

        // POST: Alumnoses/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Alumno,Nombre,Apellido_p,Apellido_m,Direccion,idcurso")] Alumnos alumnos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumnos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcurso = new SelectList(db.Curso, "id_Curso", "Nombre_Curso", alumnos.idcurso);
            return View(alumnos);
        }

        // GET: Alumnoses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnos alumnos = db.Alumnos.Find(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            return View(alumnos);
        }

        // POST: Alumnoses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alumnos alumnos = db.Alumnos.Find(id);
            db.Alumnos.Remove(alumnos);
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
