using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroupA.Dominio;
using GroupA.Web;

namespace GroupA.Web.Controllers
{
    public class EmpleadosController : Controller
    {
        private ContextoGroupA db = new ContextoGroupA();

        // GET: Empleados
        public ActionResult Index()
        {
            if (Request.IsAuthenticated) 
                return View(db.Empleados.Where<Empleado>(c => c.BorradoLogico == false).ToList());
            else return HttpNotFound();
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (Request.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Empleado empleado = db.Empleados.Find(id);
                if (empleado == null)
                {
                    return HttpNotFound();
                }
                return View(empleado);
            }
            else return HttpNotFound();
            
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            if (Request.IsAuthenticated) return View();
            else return HttpNotFound();
        }

        // POST: Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Dni,Nombre,Apellido,FechaNacimiento,FechaIngreso,Rol,BorradoLogico")] Empleado empleado)
        {
            if (Request.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    db.Empleados.Add(empleado);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(empleado);
            }
            else return HttpNotFound();
           
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Request.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Empleado empleado = db.Empleados.Find(id);
                if (empleado == null)
                {
                    return HttpNotFound();
                }
                return View(empleado);
            }
            else return HttpNotFound();
            
        }

        // POST: Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Dni,Nombre,Apellido,FechaNacimiento,FechaIngreso,Rol,BorradoLogico")] Empleado empleado)
        {
            if (Request.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(empleado).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(empleado);
            }
            else return HttpNotFound();
           
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Request.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Empleado empleado = db.Empleados.Find(id);
                if (empleado == null)
                {
                    return HttpNotFound();
                }
                return View(empleado);
            }
            else return HttpNotFound();
            
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Request.IsAuthenticated)
            {
                Empleado empleado = db.Empleados.Find(id);
                db.Empleados.Remove(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else return HttpNotFound();
           
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
