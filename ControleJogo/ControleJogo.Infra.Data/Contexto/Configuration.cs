using System.Data.Entity;

namespace ControleJogo.Infra.Data.Contexto
{
    public class Configuration : DbConfiguration
    {
        protected internal Configuration()
        {
            SetProviderServices(System.Data.Entity.SqlServer.SqlProviderServices.ProviderInvariantName, System.Data.Entity.SqlServer.SqlProviderServices.Instance);
            SetDefaultConnectionFactory(new System.Data.Entity.Infrastructure.SqlConnectionFactory());
        }
    }
}
