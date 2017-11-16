using ControleJogo.Dominio.Emprestimo.Entities;
using System;
using ControleJogo.Infra.Data.Contexto;
using ControleJogo.Dominio.Emprestimo.Repository;

namespace ControleJogo.Infra.Data.Repositories
{
    public class EmprestimoJogoRepository : RepositoryBase<EmprestimoJogo, Guid>, IEmprestimoJogoRepository
    {
        public EmprestimoJogoRepository(ControleJogoContext ctx) : base(ctx)
        {
        }
    }
}
