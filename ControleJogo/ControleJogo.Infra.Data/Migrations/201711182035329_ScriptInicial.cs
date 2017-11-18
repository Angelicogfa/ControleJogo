namespace ControleJogo.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScriptInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Amigo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(maxLength: 120, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Estado = c.Int(nullable: false),
                        CEP = c.String(nullable: false, maxLength: 9, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 50, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 50, unicode: false),
                        Endereco = c.String(nullable: false, maxLength: 50, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 10, unicode: false),
                        Complemento = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.Jogo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                        CategoriaId = c.Guid(nullable: false),
                        ConsoleId = c.Guid(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Disponivel = c.Boolean(nullable: false),
                        FotoJogo = c.Binary(),
                        QuantidadeJogos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId)
                .ForeignKey("dbo.Console", t => t.ConsoleId)
                .Index(t => t.CategoriaId)
                .Index(t => t.ConsoleId);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Console",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 30, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmprestimoJogo", "JogoId", "dbo.Jogo");
            DropForeignKey("dbo.Jogo", "ConsoleId", "dbo.Console");
            DropForeignKey("dbo.Jogo", "CategoriaId", "dbo.Categoria");
            DropForeignKey("dbo.EmprestimoJogo", "AmigoId", "dbo.Amigo");
            DropIndex("dbo.Jogo", new[] { "ConsoleId" });
            DropIndex("dbo.Jogo", new[] { "CategoriaId" });
            DropIndex("dbo.EmprestimoJogo", new[] { "AmigoId" });
            DropIndex("dbo.EmprestimoJogo", new[] { "JogoId" });
            DropTable("dbo.Console");
            DropTable("dbo.Categoria");
            DropTable("dbo.Jogo");
            DropTable("dbo.EmprestimoJogo");
            DropTable("dbo.Amigo");
        }
    }
}
