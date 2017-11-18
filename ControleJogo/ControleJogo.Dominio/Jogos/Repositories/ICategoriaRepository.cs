using ControleJogo.Dominio.Jogos.Entities;
using DomainDrivenDesign.Repositories;
using System;
using System.Threading.Tasks;

namespace ControleJogo.Dominio.Jogos.Repositories
{
    public interface ICategoriaRepository : IRepository<Categoria, Guid>
    {
        Task<bool> DescricaoEhUnica(Guid id, string descricao);
        Task<bool> PossuiJogos(Guid id);
    }
}
