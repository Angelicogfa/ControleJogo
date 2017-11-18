using CQRS.Commands;
using System;

namespace ControleJogo.Dominio.Emprestimo.Commands
{
    public class RenovarEmprestimoCommand : Command
    {
        public Guid EmprestimoId { get; private set; }
        public RenovarEmprestimoCommand(Guid Id)
        {
            EmprestimoId = Id;
        }
    }
}
