namespace ControleJogo.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Script00002 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Amigo", "Cidade", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Amigo", "Cidade");
        }
    }
}
