using System;
using System.Threading.Tasks;

namespace ControleJogo.Aplicacao.Services
{
    public interface IEmprestimoJogoAppService
    {
        Task NovoEmprestimo(Guid Jogo, Guid Amigo);
    }
}
