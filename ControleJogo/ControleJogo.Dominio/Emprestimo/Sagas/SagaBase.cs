using CQRS.DomainEvents;
using DomainDrivenDesign.Repositories;
using MediatR;
using System.Threading.Tasks;

namespace ControleJogo.Dominio.Emprestimo.Sagas
{
    public abstract class SagaBase
    {
        readonly IUnitOfWork _uow;
        protected readonly IMediator _mediator;

        public SagaBase(IUnitOfWork uow, IMediator mediator)
        {
            _uow = uow;
            _mediator = mediator;
        }

        public Task<bool> Commit()
        {
            return _uow.Commit();
        }
    }
}
