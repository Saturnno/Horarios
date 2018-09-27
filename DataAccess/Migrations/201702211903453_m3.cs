namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoriaId = c.Int(),
                        Clave = c.String(maxLength: 15),
                        NombreMateria = c.String(maxLength: 250),
                        Seriacion = c.String(maxLength: 15),
                        Creditos = c.Int(nullable: false),
                        horas = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipoCalificacion = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Meses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Materias", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Materias", new[] { "CategoriaId" });
            DropTable("dbo.Meses");
            DropTable("dbo.Materias");
            DropTable("dbo.Categorias");
        }
    }
}
