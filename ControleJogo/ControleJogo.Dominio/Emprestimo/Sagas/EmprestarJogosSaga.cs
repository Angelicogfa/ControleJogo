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
        IAsyncRequestHandler<AtualizarStatusJogoDisponivelCommand>,
        IAsyncRequestHandler<AtualizarStatusDevolucaoEmprestimoCommand>,
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
                {
                    await _mediator.Publish(new EmprestimoEfetuadoEvent(emprestimo.Id));
                    await _mediator.Send(new AtualizarStatusJogoDisponivelCommand(message.Jogo));
                }
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new DomainEvent("", ex.Message));
            }
        }

        public async Task Handle(JogoNaoDisponivelEvent notification)
        {
            //ToDo para manipular quando o jogo não estiver disponivel

            var nomeJogo = jogoRepository.Buscar().Where(t => t.Id == notification.JogoId).FirstOrDefault().Nome ?? notification.JogoId.ToString();
            await _mediator.Publish(new DomainEvent("", $"Jogo {nomeJogo} não está disponível para emprestimo!"));
        }

        public async Task Handle(AtualizarStatusJogoDisponivelCommand message)
        {
            var jogo = await jogoRepository.ProcurarPeloId(message.JogoId);
            jogo.AtualizarStatus();
            jogoRepository.Atualizar(jogo);
            await Commit();
        }

        public async Task Handle(AtualizarStatusDevolucaoEmprestimoCommand message)
        {
            var emprestimo = await emprestimoJogoRepository.ProcurarPeloId(message.EmprestimoId);
            emprestimo.AlterarStatusDevolvido(message.Devolvido);
            emprestimoJogoRepository.Atualizar(emprestimo);

            if (await Commit())
                await _mediator.Send(new AtualizarStatusJogoDisponivelCommand(emprestimo.JogoId));
        }
    }
}
