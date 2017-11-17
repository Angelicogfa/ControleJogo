using ControleJogo.Infra.Data.Contexto;
using DomainDrivenDesign.Repositories;
using System;
using System.Threading.Tasks;

namespace ControleJogo.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        readonly ControleJogoContext ctx;
        public UnitOfWork(ControleJogoContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<bool> Commit()
        {
            return (await ctx.SaveChangesAsync()) > 0;
        }

        public void Dispose()
        {
            ctx.Dispose();
        }
    }
}
