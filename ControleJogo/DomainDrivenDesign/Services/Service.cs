using DomainDrivenDesign.Entities;
using DomainDrivenDesign.Repositories;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Services
{
    public class Service<T, A> : IService<T, A> where T : Entity<A>
    {
        protected readonly IRepository<T, A> _repository;

        public Service(IRepository<T, A> repository)
        {
            _repository = repository;
        }

        public virtual T Adicionar(T obj)
        {
            return _repository.Adicionar(obj);
        }

        public virtual T Atualizar(T obj)
        {
            return _repository.Atualizar(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public Task<T> ProcurarPeloId(A Id)
        {
            return _repository.ProcurarPeloId(Id);
        }

        public virtual T Remover(T obj)
        {
            return _repository.Remover(obj);
        }
    }
}
