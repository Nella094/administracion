using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupA.Dominio
{
    public class Inasistencia
    {
        //Atributos
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        //Relaciones
        public virtual Empleado Empleado { get; set; }
    }
}
