using CQRS.Events;
using MediatR;
using System;

namespace ControleJogo.Dominio.Emprestimo.Events
{
    public class JogoNaoDisponivelEvent : Event, INotification
    {
        public Guid JogoId { get; private set; }
        public JogoNaoDisponivelEvent(Guid Jogo)
        {
            this.JogoId = Jogo;
        }
    }
}
