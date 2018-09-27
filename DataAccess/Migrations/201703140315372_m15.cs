namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProgramasEducativosDetalle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProgamaEducativoId = c.Int(),
                        MateriaId = c.Int(),
                        TrimestreId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materias", t => t.MateriaId)
                .ForeignKey("dbo.ProgramasEducativos", t => t.ProgamaEducativoId)
                .ForeignKey("dbo.Trimestres", t => t.TrimestreId)
                .Index(t => t.ProgamaEducativoId)
                .Index(t => t.MateriaId)
                .Index(t => t.TrimestreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProgramasEducativosDetalle", "TrimestreId", "dbo.Trimestres");
            DropForeignKey("dbo.ProgramasEducativosDetalle", "ProgamaEducativoId", "dbo.ProgramasEducativos");
            DropForeignKey("dbo.ProgramasEducativosDetalle", "MateriaId", "dbo.Materias");
            DropIndex("dbo.ProgramasEducativosDetalle", new[] { "TrimestreId" });
            DropIndex("dbo.ProgramasEducativosDetalle", new[] { "MateriaId" });
            DropIndex("dbo.ProgramasEducativosDetalle", new[] { "ProgamaEducativoId" });
            DropTable("dbo.ProgramasEducativosDetalle");
        }
    }
}
