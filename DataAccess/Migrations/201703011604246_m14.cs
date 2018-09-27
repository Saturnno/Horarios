namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m14 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PerfilesDocentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaestroId = c.Int(),
                        MateriaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Maestros", t => t.MaestroId)
                .ForeignKey("dbo.Materias", t => t.MateriaId)
                .Index(t => t.MaestroId)
                .Index(t => t.MateriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PerfilesDocentes", "MateriaId", "dbo.Materias");
            DropForeignKey("dbo.PerfilesDocentes", "MaestroId", "dbo.Maestros");
            DropIndex("dbo.PerfilesDocentes", new[] { "MateriaId" });
            DropIndex("dbo.PerfilesDocentes", new[] { "MaestroId" });
            DropTable("dbo.PerfilesDocentes");
        }
    }
}
