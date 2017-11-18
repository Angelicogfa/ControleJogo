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

        public async Task<bool> DescricaoEhUnica(Guid id, string descricao)
        {
            return !(await _ctx.Consoles.Where(t => t.Id != id).AnyAsync(t => t.Descricao.Equals(descricao)));
        }

        public Task<bool> PossuiJogos(Guid id)
        {
            return _ctx.Jogos.Where(t => t.ConsoleId == id).AnyAsync();
        }
    }
}
