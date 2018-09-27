namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grupos", "Nombre", c => c.String());
            DropColumn("dbo.Grupos", "Descripcion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Grupos", "Descripcion", c => c.String());
            DropColumn("dbo.Grupos", "Nombre");
        }
    }
}
