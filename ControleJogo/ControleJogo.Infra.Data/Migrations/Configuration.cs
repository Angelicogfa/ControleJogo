namespace ControleJogo.Infra.Data.Migrations
{
    using ControleJogo.Infra.Data.Contexto;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<ControleJogoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            SetHistoryContextFactory("System.Data.SqlClient", (c, d) => new ControleJogoHistory(c, d));
        }

        protected override void Seed(ControleJogo.Infra.Data.Contexto.ControleJogoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
