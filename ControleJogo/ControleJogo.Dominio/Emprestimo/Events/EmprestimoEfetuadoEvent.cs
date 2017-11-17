using CQRS.Events;
using System;

namespace ControleJogo.Dominio.Emprestimo.Events
{
    public class EmprestimoEfetuadoEvent : Event
    {
        public Guid EmprestimoId { get; private set; }

        public EmprestimoEfetuadoEvent(Guid EmprestimoId)
        {
            this.EmprestimoId = EmprestimoId;
        }
    }
}
