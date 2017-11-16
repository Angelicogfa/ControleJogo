using DomainDrivenDesign.Entities;
using System;

namespace DomainDrivenDesign.Services
{
    public interface IService<T, A> : IDisposable where T : Entity<A>
    {
        T Adicionar(T obj);
        T Atualizar(T obj);
        T Remover(T obj);
    }
}
