using ControleJogo.Dominio.Jogos.Entities;
using ControleJogo.Dominio.Jogos.Repositories;
using System;
using ControleJogo.Infra.Data.Contexto;

namespace ControleJogo.Infra.Data.Repositories
{
    public class JogoRepository : RepositoryBase<Jogo, Guid>, IJogoRepository
    {
        public JogoRepository(ControleJogoContext ctx) : base(ctx)
        {
        }
    }
}
