namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Modulos", "FechaInicio", c => c.String());
            AlterColumn("dbo.Modulos", "FechaFinal", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Modulos", "FechaFinal", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Modulos", "FechaInicio", c => c.DateTime(nullable: false));
        }
    }
}
