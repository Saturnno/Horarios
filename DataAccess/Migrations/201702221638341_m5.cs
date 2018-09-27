namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Modulos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaInicio = c.String(maxLength: 8),
                        FechaFinal = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Modulos");
        }
    }
}
