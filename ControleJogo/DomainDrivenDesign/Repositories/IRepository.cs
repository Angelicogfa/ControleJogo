using DomainDrivenDesign.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Repositories
{
    public interface IRepository<T, A>: IDisposable where T : Entity<A>
    {
        T Adicionar(T obj);
        T Atualizar(T obj);
        T Remover(T obj);
        IQueryable<T> Buscar();
        Task<T> ProcurarPeloId(A Id);
    }
}
