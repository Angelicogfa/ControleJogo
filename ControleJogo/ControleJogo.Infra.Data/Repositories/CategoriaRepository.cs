using ControleJogo.Dominio.Jogos.Entities;
using ControleJogo.Dominio.Jogos.Repositories;
using System;
using ControleJogo.Infra.Data.Contexto;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace ControleJogo.Infra.Data.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria, Guid>, ICategoriaRepository
    {
        public CategoriaRepository(ControleJogoContext ctx) : base(ctx)
        {
        }

        public async Task<bool> DescricaoEhUnica(Guid id, string descricao)
        {
            return !(await _ctx.Categorias.Where(t => t.Id != id).AnyAsync(t => t.Descricao.Equals(descricao)));
        }
    }
}
