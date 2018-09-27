namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grupos", "Año", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Grupos", "Año");
        }
    }
}
