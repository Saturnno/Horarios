namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Modulos", "FechaInicio", c => c.String(maxLength: 250));
            AlterColumn("dbo.Modulos", "FechaFinal", c => c.String(maxLength: 350));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Modulos", "FechaFinal", c => c.String(maxLength: 30));
            AlterColumn("dbo.Modulos", "FechaInicio", c => c.String(maxLength: 30));
        }
    }
}
