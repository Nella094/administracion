namespace GroupA.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class elefante : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dni = c.Int(nullable: false),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                        Rol = c.Int(nullable: false),
                        BorradoLogico = c.Boolean(nullable: false),
                        Sector_Id = c.Int(),
                        Sector_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sectores", t => t.Sector_Id)
                .ForeignKey("dbo.Sectores", t => t.Sector_Id1)
                .Index(t => t.Sector_Id)
                .Index(t => t.Sector_Id1);
            
            CreateTable(
                "dbo.HistorialProyectoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Activo = c.Boolean(nullable: false),
                        Empleado_Id = c.Int(),
                        Proyecto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empleados", t => t.Empleado_Id)
                .ForeignKey("dbo.Proyectos", t => t.Proyecto_Id)
                .Index(t => t.Empleado_Id)
                .Index(t => t.Proyecto_Id);
            
            CreateTable(
                "dbo.Proyectos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaInicio = c.DateTime(nullable: false),
                        BorradoLogico = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Inasistencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Empleado_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empleados", t => t.Empleado_Id)
                .Index(t => t.Empleado_Id);
            
            CreateTable(
                "dbo.Sectores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Gerente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empleados", t => t.Gerente_Id)
                .Index(t => t.Gerente_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleados", "Sector_Id1", "dbo.Sectores");
            DropForeignKey("dbo.Sectores", "Gerente_Id", "dbo.Empleados");
            DropForeignKey("dbo.Empleados", "Sector_Id", "dbo.Sectores");
            DropForeignKey("dbo.Inasistencias", "Empleado_Id", "dbo.Empleados");
            DropForeignKey("dbo.HistorialProyectoes", "Proyecto_Id", "dbo.Proyectos");
            DropForeignKey("dbo.HistorialProyectoes", "Empleado_Id", "dbo.Empleados");
            DropIndex("dbo.Sectores", new[] { "Gerente_Id" });
            DropIndex("dbo.Inasistencias", new[] { "Empleado_Id" });
            DropIndex("dbo.HistorialProyectoes", new[] { "Proyecto_Id" });
            DropIndex("dbo.HistorialProyectoes", new[] { "Empleado_Id" });
            DropIndex("dbo.Empleados", new[] { "Sector_Id1" });
            DropIndex("dbo.Empleados", new[] { "Sector_Id" });
            DropTable("dbo.Sectores");
            DropTable("dbo.Inasistencias");
            DropTable("dbo.Proyectos");
            DropTable("dbo.HistorialProyectoes");
            DropTable("dbo.Empleados");
        }
    }
}
