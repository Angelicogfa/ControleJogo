using ControleJogo.Infra.Data.Contexto;
using DomainDrivenDesign.Entities;
using DomainDrivenDesign.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace ControleJogo.Infra.Data.Repositories
{
    public abstract class RepositoryBase<T, A> : IRepository<T, A> where T : Entity<A>
    {
        protected readonly ControleJogoContext _ctx;
        public RepositoryBase(ControleJogoContext ctx)
        {
            _ctx = ctx;
        }

        public T Adicionar(T obj)
        {
            return _ctx.Set<T>().Add(obj);
        }

        public T Atualizar(T obj)
        {
            if (_ctx.Entry(obj).State == System.Data.Entity.EntityState.Detached)
                _ctx.Set<T>().Attach(obj);

            _ctx.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            return obj;
        }

        public IQueryable<T> Buscar()
        {
            return _ctx.Set<T>();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public virtual Task<T> ProcurarPeloId(A Id)
        {
            return _ctx.Set<T>().FindAsync(Id);
        }

        public T Remover(T obj)
        {
            if (_ctx.Entry(obj).State == System.Data.Entity.EntityState.Detached)
                _ctx.Set<T>().Attach(obj);

            return _ctx.Set<T>().Remove(obj);
        }
    }
}
