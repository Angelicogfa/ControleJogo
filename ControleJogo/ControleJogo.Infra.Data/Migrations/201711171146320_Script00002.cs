namespace ControleJogo.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Script00002 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Console",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 30),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Jogo", "ConsoleId", c => c.Guid(nullable: false));
            AddColumn("dbo.Jogo", "FotoJogo", c => c.Binary());
            CreateIndex("dbo.Jogo", "ConsoleId");
            AddForeignKey("dbo.Jogo", "ConsoleId", "dbo.Console", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jogo", "ConsoleId", "dbo.Console");
            DropIndex("dbo.Jogo", new[] { "ConsoleId" });
            DropColumn("dbo.Jogo", "FotoJogo");
            DropColumn("dbo.Jogo", "ConsoleId");
            DropTable("dbo.Console");
        }
    }
}
