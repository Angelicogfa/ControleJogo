using CQRS.Commands;
using FluentValidation.Results;
using System;

namespace ControleJogo.Dominio.Emprestimo.Commands
{
    public class NovoEmprestimoCommand : Command
    {
        public Guid Jogo { get; private set; }
        public Guid Amigo { get; private set; }
        public DateTime DataDevolucao { get; private set; }

        public NovoEmprestimoCommand(Guid Jogo, Guid Amigo, DateTime DataDevolucao)
        {
            this.Amigo = Amigo;
            this.Jogo = Jogo;
            this.DataDevolucao = DataDevolucao;
        }
    }
}
