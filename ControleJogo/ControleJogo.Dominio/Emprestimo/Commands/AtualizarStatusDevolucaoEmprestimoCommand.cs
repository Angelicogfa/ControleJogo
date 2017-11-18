using CQRS.Commands;
using System;

namespace ControleJogo.Dominio.Emprestimo.Commands
{
    public class AtualizarStatusDevolucaoEmprestimoCommand : Command
    {
        public AtualizarStatusDevolucaoEmprestimoCommand(Guid emprestimoId, bool devolvido)
        {
            EmprestimoId = emprestimoId;
            Devolvido = devolvido;
        }

        public Guid EmprestimoId { get; private set; }
        public bool Devolvido { get; private set; }
    }
}
