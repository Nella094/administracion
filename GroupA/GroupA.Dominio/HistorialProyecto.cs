using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupA.Dominio
{
    public class HistorialProyecto
    {
        //Clase Para Relacionar Proyectos con Personas
        public int Id { get; set; }
        public virtual Proyecto Proyecto { get; set; }
        public virtual Empleado Empleado { get; set; }
        public bool Activo { get; set; }
    }
}
