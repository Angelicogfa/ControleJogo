using ControleJogo.Dominio.Jogos.Entities;
using DomainDrivenDesign.Repositories;
using System;
using System.Threading.Tasks;

namespace ControleJogo.Dominio.Jogos.Repositories
{
    public interface IJogoRepository : IRepository<Jogo, Guid>
    {
        Task<bool> NomeEhUnicoPorConsole(Guid jogoId, Guid consoleId, string nome);
    }
}
