namespace ControleJogo.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Script00001 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Amigo", "Nome", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Amigo", "Email", c => c.String(maxLength: 120, unicode: false));
            AlterColumn("dbo.Amigo", "CEP", c => c.String(nullable: false, maxLength: 9, unicode: false));
            AlterColumn("dbo.Amigo", "Bairro", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Amigo", "Endereco", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Amigo", "Numero", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AlterColumn("dbo.Amigo", "Complemento", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.Jogo", "Nome", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Categoria", "Descricao", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Console", "Descricao", c => c.String(nullable: false, maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Console", "Descricao", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Categoria", "Descricao", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Jogo", "Nome", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Amigo", "Complemento", c => c.String(maxLength: 30));
            AlterColumn("dbo.Amigo", "Numero", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Amigo", "Endereco", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Amigo", "Bairro", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Amigo", "CEP", c => c.String(nullable: false, maxLength: 9));
            AlterColumn("dbo.Amigo", "Email", c => c.String(maxLength: 120));
            AlterColumn("dbo.Amigo", "Nome", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
