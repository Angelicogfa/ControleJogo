using CQRS.Events;
using System;

namespace ControleJogo.Dominio.Emprestimo.Events
{
    public class JogoNaoDisponivelEvent : Event
    {
        public Guid JogoId { get; private set; }
        public JogoNaoDisponivelEvent(Guid Jogo)
        {
            this.JogoId = Jogo;
        }
    }
}
