using System;
using System.Threading.Tasks;
using DomainDrivenDesign.Repositories;


namespace ControleJogo.Dominio.Jogos.Repositories
{
    public interface IConsoleRepository : IRepository<Entities.Console, Guid>
    {
        Task<bool> DescricaoEhUnica(Guid id, string descricao);
    }
}
