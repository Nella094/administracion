using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace GroupA.Dominio
{
    public class Empleado
    {
        //Atributos       

        public int Id { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string  Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public RolEmpleado Rol { get; set; }
        public bool BorradoLogico { get; set; }

        //Relaciones
        public virtual Sector Sector { get; set; }
        public virtual List<Inasistencia> Inasistencias { get; set; }
        public virtual List<HistorialProyecto> HistorialProyectos { get; set; }



    }
    public enum RolEmpleado
    {
        Empleado,
        Administrador
    }
}