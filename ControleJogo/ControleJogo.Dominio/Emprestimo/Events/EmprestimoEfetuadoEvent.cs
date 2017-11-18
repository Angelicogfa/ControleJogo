using CQRS.Events;
using MediatR;
using System;

namespace ControleJogo.Dominio.Emprestimo.Events
{
    public class EmprestimoEfetuadoEvent : Event, INotification
    {
        public Guid EmprestimoId { get; private set; }

        public EmprestimoEfetuadoEvent(Guid EmprestimoId)
        {
            this.EmprestimoId = EmprestimoId;
        }
    }
}
