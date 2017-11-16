using System.Threading.Tasks;
using ControleJogo.Dominio.Emprestimo.Commands;
using DomainDrivenDesign.Repositories;
using MediatR;
using ControleJogo.Dominio.Emprestimo.Repository;

namespace ControleJogo.Dominio.Emprestimo.Sagas
{
    public class EmprestarJogosSaga : SagaBase,
        IAsyncRequestHandler<NovoEmprestimoCommand>
    {
        readonly IEmprestimoJogoRepository emprestimoRepository;

        public EmprestarJogosSaga(IUnitOfWork uow, IMediator mediator, IEmprestimoJogoRepository emprestimoRepository) : base(uow, mediator)
        {
            this.emprestimoRepository = emprestimoRepository;
        }

        public Task Handle(NovoEmprestimoCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}
