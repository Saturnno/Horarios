namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m23 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GrupoDisponibilidad", "ModuloGrupoId", "dbo.ModulosGrupo");
            DropIndex("dbo.GrupoDisponibilidad", new[] { "ModuloGrupoId" });
            AddColumn("dbo.GrupoDisponibilidad", "ModuloId", c => c.Int());
            CreateIndex("dbo.GrupoDisponibilidad", "ModuloId");
            AddForeignKey("dbo.GrupoDisponibilidad", "ModuloId", "dbo.Modulos", "Id");
            DropColumn("dbo.GrupoDisponibilidad", "ModuloGrupoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GrupoDisponibilidad", "ModuloGrupoId", c => c.Int());
            DropForeignKey("dbo.GrupoDisponibilidad", "ModuloId", "dbo.Modulos");
            DropIndex("dbo.GrupoDisponibilidad", new[] { "ModuloId" });
            DropColumn("dbo.GrupoDisponibilidad", "ModuloId");
            CreateIndex("dbo.GrupoDisponibilidad", "ModuloGrupoId");
            AddForeignKey("dbo.GrupoDisponibilidad", "ModuloGrupoId", "dbo.ModulosGrupo", "Id");
        }
    }
}
