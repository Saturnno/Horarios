namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Nombramientos", "MaxHoras", c => c.Decimal(nullable: false, precision: 3, scale: 1));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Nombramientos", "MaxHoras", c => c.Decimal(nullable: false, precision: 2, scale: 1));
        }
    }
}
