using ControleJogo.Dominio.Jogos.Entities;
using ControleJogo.Dominio.Jogos.Repositories;
using System;
using ControleJogo.Infra.Data.Contexto;

namespace ControleJogo.Infra.Data.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria, Guid>, ICategoriaRepository
    {
        public CategoriaRepository(ControleJogoContext ctx) : base(ctx)
        {
        }
    }
}
