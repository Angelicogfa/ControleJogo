using ControleJogo.Dominio.Emprestimo.Commands;
using MediatR;
using System;
using System.Threading.Tasks;

namespace ControleJogo.Aplicacao.Services
{
    public class EmprestimoJogoAppService : IEmprestimoJogoAppService
    {
        readonly IMediator mediator;
        public EmprestimoJogoAppService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task NovoEmprestimo(Guid Jogo, Guid Amigo)
        {
            await mediator.Send(new NovoEmprestimoCommand(Jogo, Amigo, DateTime.Now.AddDays(7)));
        }
    }
}
