namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trimestres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 250),
                        MesId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meses", t => t.MesId)
                .Index(t => t.MesId);
            
            CreateTable(
                "dbo.Turnos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trimestres", "MesId", "dbo.Meses");
            DropIndex("dbo.Trimestres", new[] { "MesId" });
            DropTable("dbo.Turnos");
            DropTable("dbo.Trimestres");
        }
    }
}
