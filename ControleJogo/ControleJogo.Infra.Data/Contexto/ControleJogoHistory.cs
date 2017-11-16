using System.Data.Entity;
using System.Data.Entity.Migrations.History;

namespace ControleJogo.Infra.Data.Contexto
{
    public class ControleJogoHistory : HistoryContext
    {
        public ControleJogoHistory(System.Data.Common.DbConnection existingConnection, string defaultSchema) : base(existingConnection, defaultSchema)
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HistoryRow>().ToTable("ControleJogoHistory");
        }
    }
}
