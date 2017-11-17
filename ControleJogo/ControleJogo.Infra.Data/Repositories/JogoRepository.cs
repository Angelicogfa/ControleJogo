using ControleJogo.Dominio.Jogos.Entities;
using ControleJogo.Dominio.Jogos.Repositories;
using System;
using ControleJogo.Infra.Data.Contexto;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace ControleJogo.Infra.Data.Repositories
{
    public class JogoRepository : RepositoryBase<Jogo, Guid>, IJogoRepository
    {
        public JogoRepository(ControleJogoContext ctx) : base(ctx)
        {
        }

        public override async Task<Jogo> ProcurarPeloId(Guid Id)
        {
            var jogo = await (from jogos in _ctx.Jogos
                        join emprestimos in _ctx.Emprestimos on jogos.Id equals emprestimos.JogoId
                        where jogos.Id == Id && !emprestimos.Devolvido
                        select jogos).FirstOrDefaultAsync();

            return jogo;
        }
    }
}
