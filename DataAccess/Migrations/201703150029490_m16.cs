namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m16 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grupos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Aula = c.String(),
                        TrimestreId = c.Int(),
                        ProgramaEducativoId = c.Int(),
                        TurnoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProgramasEducativos", t => t.ProgramaEducativoId)
                .ForeignKey("dbo.Trimestres", t => t.TrimestreId)
                .ForeignKey("dbo.Turnos", t => t.TurnoId)
                .Index(t => t.TrimestreId)
                .Index(t => t.ProgramaEducativoId)
                .Index(t => t.TurnoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grupos", "TurnoId", "dbo.Turnos");
            DropForeignKey("dbo.Grupos", "TrimestreId", "dbo.Trimestres");
            DropForeignKey("dbo.Grupos", "ProgramaEducativoId", "dbo.ProgramasEducativos");
            DropIndex("dbo.Grupos", new[] { "TurnoId" });
            DropIndex("dbo.Grupos", new[] { "ProgramaEducativoId" });
            DropIndex("dbo.Grupos", new[] { "TrimestreId" });
            DropTable("dbo.Grupos");
        }
    }
}
