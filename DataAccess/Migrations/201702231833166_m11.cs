namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Maestros",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 250),
                        Contrato = c.String(maxLength: 250),
                        ContratoConfidencial = c.String(maxLength: 250),
                        ProgramaEducativoId = c.Int(),
                        UnidadId = c.Int(),
                        DepartamentoId = c.Int(),
                        NombramientoId = c.Int(),
                        Orden = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departamentos", t => t.DepartamentoId)
                .ForeignKey("dbo.Nombramientos", t => t.NombramientoId)
                .ForeignKey("dbo.ProgramasEducativos", t => t.ProgramaEducativoId)
                .ForeignKey("dbo.Unidades", t => t.UnidadId)
                .Index(t => t.ProgramaEducativoId)
                .Index(t => t.UnidadId)
                .Index(t => t.DepartamentoId)
                .Index(t => t.NombramientoId);
            
            AddColumn("dbo.Materias", "Nombre", c => c.String(maxLength: 250));
            AddColumn("dbo.ProgramasEducativos", "UnidadId", c => c.Int());
            AlterColumn("dbo.Materias", "Horas", c => c.Decimal(nullable: false, precision: 2, scale: 1));
            CreateIndex("dbo.ProgramasEducativos", "UnidadId");
            AddForeignKey("dbo.ProgramasEducativos", "UnidadId", "dbo.Unidades", "Id");
            DropColumn("dbo.Materias", "NombreMateria");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Materias", "NombreMateria", c => c.String(maxLength: 250));
            DropForeignKey("dbo.Maestros", "UnidadId", "dbo.Unidades");
            DropForeignKey("dbo.Maestros", "ProgramaEducativoId", "dbo.ProgramasEducativos");
            DropForeignKey("dbo.ProgramasEducativos", "UnidadId", "dbo.Unidades");
            DropForeignKey("dbo.Maestros", "NombramientoId", "dbo.Nombramientos");
            DropForeignKey("dbo.Maestros", "DepartamentoId", "dbo.Departamentos");
            DropIndex("dbo.ProgramasEducativos", new[] { "UnidadId" });
            DropIndex("dbo.Maestros", new[] { "NombramientoId" });
            DropIndex("dbo.Maestros", new[] { "DepartamentoId" });
            DropIndex("dbo.Maestros", new[] { "UnidadId" });
            DropIndex("dbo.Maestros", new[] { "ProgramaEducativoId" });
            AlterColumn("dbo.Materias", "Horas", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.ProgramasEducativos", "UnidadId");
            DropColumn("dbo.Materias", "Nombre");
            DropTable("dbo.Maestros");
        }
    }
}
