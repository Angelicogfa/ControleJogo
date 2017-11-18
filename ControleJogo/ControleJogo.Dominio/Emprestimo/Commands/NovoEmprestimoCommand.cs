using CQRS.Commands;
using MediatR;
using System;

namespace ControleJogo.Dominio.Emprestimo.Commands
{
    public class NovoEmprestimoCommand : Command
    {
        public Guid Jogo { get; private set; }
        public Guid Amigo { get; private set; }

        public NovoEmprestimoCommand(Guid Jogo, Guid Amigo)
        {
            this.Amigo = Amigo;
            this.Jogo = Jogo;
        }
    }
}
