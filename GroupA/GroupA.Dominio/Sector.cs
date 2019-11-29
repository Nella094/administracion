using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupA.Dominio
{
    public class Sector
    {
        //Atributos
        public int Id { get; set; }
        public string Nombre { get; set; }
        //Relaciones
        public virtual List<Empleado> Empleados { get; set; }
        public Empleado Gerente { get; set; }

    }
}