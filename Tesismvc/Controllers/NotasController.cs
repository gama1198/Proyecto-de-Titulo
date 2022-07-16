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
    public class NotasController : Controller
    {
        private Sistema_Escolar_respladoEntities db = new Sistema_Escolar_respladoEntities();

        // GET: Notas
        public ActionResult Index()
        {
            var notas = db.Notas.Include(n => n.Alumnos).Include(n => n.Curso).Include(n => n.Docente);
            return View(notas.ToList());
        }

        // GET: Notas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notas notas = db.Notas.Find(id);
            if (notas == null)
            {
                return HttpNotFound();
            }
            return View(notas);
        }

        // GET: Notas/Create
        public ActionResult Create()
        {
            ViewBag.idalumno = new SelectList(db.Alumnos, "id_Alumno", "Nombre");
            ViewBag.idcurso = new SelectList(db.Curso, "id_Curso", "Nombre_Curso");
            ViewBag.idprofesor = new SelectList(db.Docente, "id_Docente", "Nombre");
            return View();
        }

        // POST: Notas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nota,idalumno,idcurso,idprofesor")] Notas notas)
        {
            if (ModelState.IsValid)
            {
                db.Notas.Add(notas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idalumno = new SelectList(db.Alumnos, "id_Alumno", "Nombre", notas.idalumno);
            ViewBag.idcurso = new SelectList(db.Curso, "id_Curso", "Nombre_Curso", notas.idcurso);
            ViewBag.idprofesor = new SelectList(db.Docente, "id_Docente", "Nombre", notas.idprofesor);
            return View(notas);
        }

        // GET: Notas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notas notas = db.Notas.Find(id);
            if (notas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idalumno = new SelectList(db.Alumnos, "id_Alumno", "Nombre", notas.idalumno);
            ViewBag.idcurso = new SelectList(db.Curso, "id_Curso", "Nombre_Curso", notas.idcurso);
            ViewBag.idprofesor = new SelectList(db.Docente, "id_Docente", "Nombre", notas.idprofesor);
            return View(notas);
        }

        // POST: Notas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nota,idalumno,idcurso,idprofesor")] Notas notas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idalumno = new SelectList(db.Alumnos, "id_Alumno", "Nombre", notas.idalumno);
            ViewBag.idcurso = new SelectList(db.Curso, "id_Curso", "Nombre_Curso", notas.idcurso);
            ViewBag.idprofesor = new SelectList(db.Docente, "id_Docente", "Nombre", notas.idprofesor);
            return View(notas);
        }

        // GET: Notas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notas notas = db.Notas.Find(id);
            if (notas == null)
            {
                return HttpNotFound();
            }
            return View(notas);
        }

        // POST: Notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notas notas = db.Notas.Find(id);
            db.Notas.Remove(notas);
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
