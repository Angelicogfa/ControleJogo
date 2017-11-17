using System;
using ControleJogo.Infra.Data.Contexto;
using ControleJogo.Dominio.Jogos.Repositories;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace ControleJogo.Infra.Data.Repositories
{
    public class ConsoleRepository : RepositoryBase<Dominio.Jogos.Entities.Console, Guid>, IConsoleRepository
    {
        public ConsoleRepository(ControleJogoContext ctx) : base(ctx)
        {
        }

        public Task<bool> DescricaoEhUnica(Guid id, string descricao)
        {
            return _ctx.Consoles.Where(t => t.Id != id).AnyAsync(t => t.Descricao.Equals(descricao));
        }
    }
}
