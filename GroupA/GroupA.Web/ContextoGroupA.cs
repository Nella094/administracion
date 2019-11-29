namespace GroupA.Web
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using GroupA.Dominio;

    public partial class ContextoGroupA : DbContext
    {
        public ContextoGroupA()
            : base("name=ContextoGroupA")
        {
        }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Sector> Sectores { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Inasistencia> Inasistencias { get; set; }
        public DbSet<HistorialProyecto> HistorialProyectos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>().ToTable("Empleados");
            modelBuilder.Entity<Sector>().ToTable("Sectores");
            modelBuilder.Entity<Proyecto>().ToTable("Proyectos");
            modelBuilder.Entity<Inasistencia>().ToTable("Inasistencias");
        }
    }
}
