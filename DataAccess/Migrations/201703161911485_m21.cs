namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m21 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GrupoDisponibilidad",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GrupoId = c.Int(),
                        ModuloGrupoId = c.Int(),
                        MaestroId = c.Int(),
                        MateriaId = c.Int(),
                        Dia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grupos", t => t.GrupoId)
                .ForeignKey("dbo.Maestros", t => t.MaestroId)
                .ForeignKey("dbo.Materias", t => t.MateriaId)
                .ForeignKey("dbo.ModulosGrupo", t => t.ModuloGrupoId)
                .Index(t => t.GrupoId)
                .Index(t => t.ModuloGrupoId)
                .Index(t => t.MaestroId)
                .Index(t => t.MateriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GrupoDisponibilidad", "ModuloGrupoId", "dbo.ModulosGrupo");
            DropForeignKey("dbo.GrupoDisponibilidad", "MateriaId", "dbo.Materias");
            DropForeignKey("dbo.GrupoDisponibilidad", "MaestroId", "dbo.Maestros");
            DropForeignKey("dbo.GrupoDisponibilidad", "GrupoId", "dbo.Grupos");
            DropIndex("dbo.GrupoDisponibilidad", new[] { "MateriaId" });
            DropIndex("dbo.GrupoDisponibilidad", new[] { "MaestroId" });
            DropIndex("dbo.GrupoDisponibilidad", new[] { "ModuloGrupoId" });
            DropIndex("dbo.GrupoDisponibilidad", new[] { "GrupoId" });
            DropTable("dbo.GrupoDisponibilidad");
        }
    }
}
