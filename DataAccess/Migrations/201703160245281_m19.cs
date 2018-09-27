namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m19 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grupos", "Ano", c => c.Int(nullable: false));
            DropColumn("dbo.Grupos", "Año");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Grupos", "Año", c => c.Int(nullable: false));
            DropColumn("dbo.Grupos", "Ano");
        }
    }
}
