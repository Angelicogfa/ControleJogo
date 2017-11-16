using ControleJogo.Dominio.Emprestimo.Entities;
using DomainDrivenDesign.Repositories;
using System;

namespace ControleJogo.Dominio.Emprestimo.Repository
{
    public interface IEmprestimoJogoRepository : IRepository<EmprestimoJogo, Guid>
    {
    }
}
