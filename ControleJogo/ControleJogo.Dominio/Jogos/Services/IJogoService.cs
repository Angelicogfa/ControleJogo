using ControleJogo.Dominio.Jogos.Entities;
using DomainDrivenDesign.Services;
using System;
using System.Threading.Tasks;

namespace ControleJogo.Dominio.Jogos.Services
{
    public interface IJogoService : IService<Jogo, Guid>
    {
        Task<bool> JogoDisponivelParaEmprestimo(Guid JogoId);
    }
}
