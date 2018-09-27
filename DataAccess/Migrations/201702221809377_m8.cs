namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Modulos", "FechaInicio", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Modulos", "FechaFinal", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Modulos", "FechaFinal", c => c.String(maxLength: 350));
            AlterColumn("dbo.Modulos", "FechaInicio", c => c.String(maxLength: 250));
        }
    }
}
