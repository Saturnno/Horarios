namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GrupoDisponibilidad", "TrimestreId", c => c.Int());
            CreateIndex("dbo.GrupoDisponibilidad", "TrimestreId");
            AddForeignKey("dbo.GrupoDisponibilidad", "TrimestreId", "dbo.Trimestres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GrupoDisponibilidad", "TrimestreId", "dbo.Trimestres");
            DropIndex("dbo.GrupoDisponibilidad", new[] { "TrimestreId" });
            DropColumn("dbo.GrupoDisponibilidad", "TrimestreId");
        }
    }
}
