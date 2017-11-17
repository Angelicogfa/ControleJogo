using DomainDrivenDesign.Services;
using System;

namespace ControleJogo.Dominio.Jogos.Services
{
    public interface IConsoleService : IService<Entities.Console, Guid>
    {
    }
}
