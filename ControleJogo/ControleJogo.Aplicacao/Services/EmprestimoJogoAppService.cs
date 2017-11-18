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
        IEmprestimoJogoAppService
    {
        readonly IMediator mediator;

        public EmprestimoJogoAppService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task NovoEmprestimo(Guid Jogo, Guid Amigo)
        {
            await mediator.Send(new NovoEmprestimoCommand(Jogo, Amigo));
        }

        public async Task RenovarJogoEmprestimo(Guid id)
        {
            await mediator.Send(new RenovarEmprestimoCommand(id));
        }

        public async Task DevolverJogoEmprestado(Guid Emprestimo)
        {
            await mediator.Send(new DevolverJogoCommand(Emprestimo));
        }
    }
}
