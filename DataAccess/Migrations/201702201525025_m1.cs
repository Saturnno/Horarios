namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departamentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 120),
                        JefeDepartamento = c.String(maxLength: 120),
                        UnidadId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Unidades", t => t.UnidadId)
                .Index(t => t.UnidadId);
            
            CreateTable(
                "dbo.Unidades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 150),
                        Direccion = c.String(maxLength: 256),
                        Director = c.String(maxLength: 100),
                        Telefono = c.String(),
                        Correo = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departamentos", "UnidadId", "dbo.Unidades");
            DropIndex("dbo.Departamentos", new[] { "UnidadId" });
            DropTable("dbo.Unidades");
            DropTable("dbo.Departamentos");
        }
    }
}
