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
                        Nome = c.String(nullable: false, maxLength: 50),
                        Email = c.String(maxLength: 120),
                        DataCadastro = c.DateTime(nullable: false),
                        Estado = c.Int(nullable: false),
                        CEP = c.String(nullable: false, maxLength: 9),
                        Bairro = c.String(nullable: false, maxLength: 50),
                        Endereco = c.String(nullable: false, maxLength: 50),
                        Numero = c.String(nullable: false, maxLength: 10),
                        Complemento = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Jogo",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 50),
                        CategoriaId = c.Guid(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        QuantidadeJogos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId)
                .Index(t => t.CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jogo", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Jogo", new[] { "CategoriaId" });
            DropTable("dbo.Jogo");
            DropTable("dbo.Categoria");
            DropTable("dbo.Amigo");
        }
    }
}
