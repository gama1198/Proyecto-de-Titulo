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
    public class AsistenciasController : Controller
    {
        private Sistema_Escolar_respladoEntities db = new Sistema_Escolar_respladoEntities();

        // GET: Asistencias
        public ActionResult Index()
        {
            var asistencia = db.Asistencia.Include(a => a.Alumnos).Include(a => a.Estado_Asistencia).Include(a => a.Docente).Include(a => a.Curso);
            return View(asistencia.ToList());
        }

        // GET: Asistencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = db.Asistencia.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        // GET: Asistencias/Create
        public ActionResult Create()
        {
            ViewBag.idalumno = new SelectList(db.Alumnos, "id_Alumno", "Nombre");
            ViewBag.Estado = new SelectList(db.Estado_Asistencia, "id", "Asistencia");
            ViewBag.Id_Docente = new SelectList(db.Docente, "id_Docente", "Nombre");
            ViewBag.idcurso = new SelectList(db.Curso, "id_Curso", "Nombre_Curso");
            return View();
        }

        // POST: Asistencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idasistencia,idalumno,Id_Docente,Fecha,Hora,idcurso,Estado")] Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Asistencia.Add(asistencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idalumno = new SelectList(db.Alumnos, "id_Alumno", "Nombre", asistencia.idalumno);
            ViewBag.Estado = new SelectList(db.Estado_Asistencia, "id", "Asistencia", asistencia.Estado);
            ViewBag.Id_Docente = new SelectList(db.Docente, "id_Docente", "Nombre", asistencia.Id_Docente);
            ViewBag.idcurso = new SelectList(db.Curso, "id_Curso", "Nombre_Curso", asistencia.idcurso);
            return View(asistencia);
        }

        // GET: Asistencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = db.Asistencia.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.idalumno = new SelectList(db.Alumnos, "id_Alumno", "Nombre", asistencia.idalumno);
            ViewBag.Estado = new SelectList(db.Estado_Asistencia, "id", "Asistencia", asistencia.Estado);
            ViewBag.Id_Docente = new SelectList(db.Docente, "id_Docente", "Nombre", asistencia.Id_Docente);
            ViewBag.idcurso = new SelectList(db.Curso, "id_Curso", "Nombre_Curso", asistencia.idcurso);
            return View(asistencia);
        }

        // POST: Asistencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idasistencia,idalumno,Id_Docente,Fecha,Hora,idcurso,Estado")] Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asistencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idalumno = new SelectList(db.Alumnos, "id_Alumno", "Nombre", asistencia.idalumno);
            ViewBag.Estado = new SelectList(db.Estado_Asistencia, "id", "Asistencia", asistencia.Estado);
            ViewBag.Id_Docente = new SelectList(db.Docente, "id_Docente", "Nombre", asistencia.Id_Docente);
            ViewBag.idcurso = new SelectList(db.Curso, "id_Curso", "Nombre_Curso", asistencia.idcurso);
            return View(asistencia);
        }

        // GET: Asistencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = db.Asistencia.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        // POST: Asistencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asistencia asistencia = db.Asistencia.Find(id);
            db.Asistencia.Remove(asistencia);
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
