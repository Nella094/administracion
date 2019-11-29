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
    public class ProyectosController : Controller
    {
        private ContextoGroupA db = new ContextoGroupA();

        // GET: Proyectos
        public ActionResult Index()
        {
            return View(db.Proyectos.ToList());
        }

        // GET: Proyectos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyectos.Find(id);
            var empleados = proyecto.HistorialProyectos.Where(c => c.Activo == true && c.Proyecto.Id == proyecto.Id).ToList();
            ViewBag.Empleados = empleados;
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // GET: Proyectos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proyectos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,FechaInicio,BorradoLogico")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Proyectos.Add(proyecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proyecto);
        }

        // GET: Proyectos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyectos.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // POST: Proyectos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,FechaInicio,BorradoLogico")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proyecto);
        }

        // GET: Proyectos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proyecto proyecto = db.Proyectos.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }
            return View(proyecto);
        }

        // POST: Proyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proyecto proyecto = db.Proyectos.Find(id);
            db.Proyectos.Remove(proyecto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get Proyectos/AgregarEmpleados/3
        [HttpGet]
        public ActionResult AgregarEmpleados(int? id)
        {
            if (id == null) return  new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            else
            {
                Proyecto proyecto = db.Proyectos.Find(id);
                if (proyecto == null) return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                ViewBag.Proyecto = proyecto;                
                var empleados = db.Empleados.Where(c => c.BorradoLogico == false).ToList();
                return View(empleados);
            }
            

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        // Get : Proyectos/Agregar/1
       
        [HttpPost,ActionName("AgregarEmpleados")]
        public ActionResult AgregarEmpleado(int? idProyecto, int? dniEmpleado)
        {
            if (idProyecto == null || dniEmpleado == null) return View();
            else
            {
                Proyecto proyecto = db.Proyectos.Find(idProyecto);
                Empleado empleado = db.Empleados.Where(c => c.Dni == dniEmpleado).First();
                if (proyecto == null || empleado == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                {
                    var historialProyecto = new HistorialProyecto();
                    historialProyecto.Empleado = empleado;
                    historialProyecto.Proyecto = proyecto;
                    historialProyecto.Activo = true;
                    proyecto.HistorialProyectos.Add(historialProyecto);
                    empleado.HistorialProyectos.Add(historialProyecto);
                    db.HistorialProyectos.Add(historialProyecto);
                    db.Entry(proyecto).State = EntityState.Modified;
                    db.Entry(empleado).State = EntityState.Modified;
                    db.SaveChanges();
                }

                
            }
            return RedirectToAction("Index");
        }
    }
}
