namespace ControleJogo.Infra.Identity.Migrations
{
    using ControleJogo.Infra.Identity.Storage;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            SetHistoryContextFactory("System.Data.SqlClient", (c, s) => new UserContextHistory(c, s));
        }

        protected override void Seed(UserContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
