namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m20 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModulosGrupo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaInicio = c.String(),
                        FechaFinal = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ModulosGrupo");
        }
    }
}
