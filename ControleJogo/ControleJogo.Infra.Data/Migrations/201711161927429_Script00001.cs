namespace ControleJogo.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Script00001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmprestimoJogo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        JogoId = c.Guid(nullable: false),
                        AmigoId = c.Guid(nullable: false),
                        DataEmprestimo = c.DateTime(nullable: false),
                        DataDevolucao = c.DateTime(nullable: false),
                        Devolvido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Amigo", t => t.AmigoId)
                .ForeignKey("dbo.Jogo", t => t.JogoId)
                .Index(t => t.JogoId)
                .Index(t => t.AmigoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmprestimoJogo", "JogoId", "dbo.Jogo");
            DropForeignKey("dbo.EmprestimoJogo", "AmigoId", "dbo.Amigo");
            DropIndex("dbo.EmprestimoJogo", new[] { "AmigoId" });
            DropIndex("dbo.EmprestimoJogo", new[] { "JogoId" });
            DropTable("dbo.EmprestimoJogo");
        }
    }
}
