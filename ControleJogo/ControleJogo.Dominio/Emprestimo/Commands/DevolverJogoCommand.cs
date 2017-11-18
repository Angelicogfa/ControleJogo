using CQRS.Commands;
using System;

namespace ControleJogo.Dominio.Emprestimo.Commands
{
    public class DevolverJogoCommand : Command
    {
        public DevolverJogoCommand(Guid emprestimoId)
        {
            EmprestimoId = emprestimoId;
        }

        public Guid EmprestimoId { get; private set; }
    }
}
