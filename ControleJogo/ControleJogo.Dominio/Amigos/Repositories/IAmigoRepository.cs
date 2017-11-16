using ControleJogo.Dominio.Amigos.Entities;
using DomainDrivenDesign.Repositories;
using System;
using System.Threading.Tasks;

namespace ControleJogo.Dominio.Amigos.Repositories
{
    public interface IAmigoRepository : IRepository<Amigo, Guid>
    {
        Task<bool> EmailEhUnico(Guid AmigoId, string Email);
    }
}
