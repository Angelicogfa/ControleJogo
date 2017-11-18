using ControleJogo.Dominio.Emprestimo.Commands;
using CQRS.DomainEvents;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleJogo.Aplicacao.Services
{
    public class EmprestimoJogoAppService : 
        IEmprestimoJogoAppService,
        IDisposable,
        INotificationHandler<DomainEvent>
    {
        readonly IMediator mediator;

        List<DomainEvent> events = new List<DomainEvent>();

        public EmprestimoJogoAppService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<ValidationResult> AtualizarStatusEmprestimo(Guid Emprestimo, bool Devolvido)
        {
            await mediator.Send(new AtualizarStatusDevolucaoEmprestimoCommand(Emprestimo, Devolvido));
            ValidationResult result = new ValidationResult();
            events.ForEach(t => result.Errors.Add(new ValidationFailure(t.Key, t.Value)));
            return result;
        }

        public void Dispose()
        {
            events.Clear();
        }

        public void Handle(DomainEvent notification)
        {
            events.Add(notification);
        }

        public async Task<ValidationResult> NovoEmprestimo(Guid Jogo, Guid Amigo)
        {
            await mediator.Send(new NovoEmprestimoCommand(Jogo, Amigo, DateTime.Now.AddDays(7)));
            ValidationResult result = new ValidationResult();
            events.ForEach(t => result.Errors.Add(new ValidationFailure(t.Key, t.Value)));
            return result;
        }
    }
}
