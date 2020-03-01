using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlumnosWeb.Models;

namespace AlumnosWeb.Controllers
{
    public class tbAlumnosController : Controller
    {
        private bdAlumnosEntities db = new bdAlumnosEntities();

        // GET: tbAlumnos
        public ActionResult Index()
        {
            return View(db.tbAlumnos.ToList());
        }

        // GET: tbAlumnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAlumnos tbAlumnos = db.tbAlumnos.Find(id);
            if (tbAlumnos == null)
            {
                return HttpNotFound();
            }
            return View(tbAlumnos);
        }

        // GET: tbAlumnos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbAlumnos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellidos,Edad,FechaNac")] tbAlumnos tbAlumnos)
        {
            if (ModelState.IsValid)
            {
                db.tbAlumnos.Add(tbAlumnos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbAlumnos);
        }

        // GET: tbAlumnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAlumnos tbAlumnos = db.tbAlumnos.Find(id);
            if (tbAlumnos == null)
            {
                return HttpNotFound();
            }
            return View(tbAlumnos);
        }

        // POST: tbAlumnos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellidos,Edad,FechaNac")] tbAlumnos tbAlumnos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbAlumnos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbAlumnos);
        }

        // GET: tbAlumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAlumnos tbAlumnos = db.tbAlumnos.Find(id);
            if (tbAlumnos == null)
            {
                return HttpNotFound();
            }
            return View(tbAlumnos);
        }

        // POST: tbAlumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbAlumnos tbAlumnos = db.tbAlumnos.Find(id);
            db.tbAlumnos.Remove(tbAlumnos);
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
