using ControleJogo.Infra.DatabaseRead.OutputModel;
using System;
using System.Threading.Tasks;

namespace ControleJogo.Infra.DatabaseRead.DataAcess
{
    public interface IJogoDataRead : IDatabaseRead<JogoDTO>
    {
        Task<byte[]> CarregarImagem(Guid Id);
    }
}
