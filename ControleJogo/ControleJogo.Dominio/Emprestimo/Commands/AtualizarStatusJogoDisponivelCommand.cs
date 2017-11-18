using CQRS.Commands;
using CQRS.Events;
using System;

namespace ControleJogo.Dominio.Emprestimo.Commands
{
    public class AtualizarStatusJogoDisponivelCommand : Command
    {
        public Guid JogoId { get; private set; }
        public AtualizarStatusJogoDisponivelCommand(Guid JogoId)
        {
            this.JogoId = JogoId;
        }
    }
}
