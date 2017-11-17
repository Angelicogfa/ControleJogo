namespace ControleJogo.Infra.Data.Contexto
{
    public class ControleJogoInicializer : System.Data.Entity.MigrateDatabaseToLatestVersion<ControleJogoContext, Migrations.Configuration>
    {
        public ControleJogoInicializer() : base(true)
        {
            
        }

        public override void InitializeDatabase(ControleJogoContext context)
        {
            base.InitializeDatabase(context);
        }
    }
}
