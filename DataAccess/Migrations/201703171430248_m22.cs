namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Maestros", "Disponibilidad", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Maestros", "Disponibilidad");
        }
    }
}
