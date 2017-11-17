using System.Threading.Tasks;
using ControleJogo.Dominio.Emprestimo.Commands;
using DomainDrivenDesign.Repositories;
using MediatR;
using ControleJogo.Dominio.Jogos.Repositories;
using System;
using CQRS.DomainEvents;
using ControleJogo.Dominio.Emprestimo.Events;
using System.Linq;
using ControleJogo.Dominio.Emprestimo.Repository;

namespace ControleJogo.Dominio.Emprestimo.Sagas
{
    public class EmprestarJogosSaga : SagaBase,
        IAsyncRequestHandler<NovoEmprestimoCommand>,
        IAsyncNotificationHandler<JogoNaoDisponivelEvent>
    {
        readonly IJogoRepository jogoRepository;
        readonly IEmprestimoJogoRepository emprestimoJogoRepository;

        public EmprestarJogosSaga(IUnitOfWork uow, IMediator mediator,
            IJogoRepository jogoRepository,
            IEmprestimoJogoRepository emprestimoJogoRepository) : base(uow, mediator)
        {
            this.jogoRepository = jogoRepository;
            this.emprestimoJogoRepository = emprestimoJogoRepository;
        }

        public async Task Handle(NovoEmprestimoCommand message)
        {
            try
            {
                var jogo = await jogoRepository.ProcurarPeloId(message.Jogo);
                if (jogo == null)
                    throw new InvalidOperationException($"Jogo não localizado para o Id {message.Jogo}");

                var emprestimo = jogo.NovoEmprestimo(message.Amigo);
                if (emprestimo == null)
                {
                    await _mediator.Publish(new JogoNaoDisponivelEvent(message.Jogo));
                    return;
                }

                emprestimo = emprestimoJogoRepository.Adicionar(emprestimo);
                if (await Commit())
                    await _mediator.Publish(new EmprestimoEfetuadoEvent(emprestimo.Id));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Handle(JogoNaoDisponivelEvent notification)
        {
            //ToDo para manipular quando o jogo não estiver disponivel

            var nomeJogo = jogoRepository.Buscar().Where(t => t.Id == notification.JogoId).FirstOrDefault().Nome ?? notification.JogoId.ToString();
            await _mediator.Publish(new DomainEvent("", $"Jogo {nomeJogo} não está disponível para emprestimo!"));
        }
    }
}
