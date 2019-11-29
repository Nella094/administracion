using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupA.Dominio
{
    public class Proyecto
    {
        //Atributos
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public bool BorradoLogico { get; set; }
        //Relaciones
        public virtual List<HistorialProyecto> HistorialProyectos { get; set; }
    }
}
