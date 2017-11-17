using System.Configuration;

namespace ControleJogo.Infra.DatabaseRead.DataAcess
{
    public abstract class FacadeRead
    {
        protected readonly string conexao;

        public FacadeRead()
        {
            conexao = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
        }
    }
}
