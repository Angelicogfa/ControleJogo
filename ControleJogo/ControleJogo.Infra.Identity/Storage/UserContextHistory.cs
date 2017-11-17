using System.Data.Entity;
using System.Data.Entity.Migrations.History;

namespace ControleJogo.Infra.Identity.Storage
{
    class UserContextHistory : HistoryContext
    {
        public UserContextHistory(System.Data.Common.DbConnection existingConnection, string defaultSchema) : base(existingConnection, defaultSchema)
        {
        }

        static UserContextHistory()
        {
            Database.SetInitializer(new UserContextInicialize());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HistoryRow>().ToTable("IdentityUserHistory");
        }
    }
}
