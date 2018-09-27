namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProgramasEducativos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartamentoId = c.Int(),
                        Nombre = c.String(maxLength: 250),
                        Abreviatura = c.String(maxLength: 20),
                        CordinadorAcademico = c.String(maxLength: 120),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departamentos", t => t.DepartamentoId)
                .Index(t => t.DepartamentoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProgramasEducativos", "DepartamentoId", "dbo.Departamentos");
            DropIndex("dbo.ProgramasEducativos", new[] { "DepartamentoId" });
            DropTable("dbo.ProgramasEducativos");
        }
    }
}
