using ControleJogo.Dominio.Amigos.Entities;
using System;
using ControleJogo.Infra.Data.Contexto;
using ControleJogo.Dominio.Amigos.Repositories;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace ControleJogo.Infra.Data.Repositories
{
    public class AmigoRepository : RepositoryBase<Amigo, Guid>, IAmigoRepository
    {
        public AmigoRepository(ControleJogoContext ctx) : base(ctx)
        {
        }

        public async Task<bool> EmailEhUnico(Guid AmigoId, string Email)
        {
            return !(await _ctx.Amigos.Where(t => t.Id != AmigoId).AnyAsync(t => t.Email.Value.Equals(Email)));
        }

        public Task<bool> PossuiEmprestimos(Guid id)
        {
            return _ctx.Emprestimos.Where(t => t.AmigoId == id).AnyAsync();
        }
    }
}
