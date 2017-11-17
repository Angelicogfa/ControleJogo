using DomainDrivenDesign.Services;
using System;
using ControleJogo.Dominio.Jogos.Repositories;
using ControleJogo.Dominio.Jogos.Validations;

namespace ControleJogo.Dominio.Jogos.Services
{
    public class ConsoleService : Service<Entities.Console, Guid>, IConsoleService
    {
        public ConsoleService(IConsoleRepository repository) : base(repository)
        {
        }

        public override Entities.Console Adicionar(Entities.Console obj)
        {
            if (!obj.EhValido())
                return obj;

            obj.ValidationResult = new ConsoleAptoPersistenciaValidator((IConsoleRepository)_repository).Validate(obj);
            if (!obj.ValidationResult.IsValid)
                return obj;

            return obj = base.Adicionar(obj);
        }

        public override Entities.Console Atualizar(Entities.Console obj)
        {
            if (!obj.EhValido())
                return obj;

            obj.ValidationResult = new ConsoleAptoPersistenciaValidator((IConsoleRepository)_repository).Validate(obj);
            if (!obj.ValidationResult.IsValid)
                return obj;

            return obj = base.Atualizar(obj);
        }
    }
}
