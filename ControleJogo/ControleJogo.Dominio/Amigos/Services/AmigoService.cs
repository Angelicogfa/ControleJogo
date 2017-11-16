using ControleJogo.Dominio.Amigos.Entities;
using DomainDrivenDesign.Services;
using System;
using ControleJogo.Dominio.Amigos.Repositories;
using ControleJogo.Dominio.Amigos.Validations;

namespace ControleJogo.Dominio.Amigos.Services
{
    public class AmigoService : Service<Amigo, Guid>, IAmigoService
    {
        public AmigoService(IAmigoRepository repository) : base(repository)
        {
        }

        public override Amigo Adicionar(Amigo obj)
        {
            if (!obj.EhValido())
                return obj;

            obj.ValidationResult = new AmigoAptoPersistenciaValidator((IAmigoRepository)_repository).Validate(obj);
            if (!obj.ValidationResult.IsValid)
                return obj;

            return obj = base.Adicionar(obj);
        }

        public override Amigo Atualizar(Amigo obj)
        {
            if (!obj.EhValido())
                return obj;

            obj.ValidationResult = new AmigoAptoPersistenciaValidator((IAmigoRepository)_repository).Validate(obj);
            if (!obj.ValidationResult.IsValid)
                return obj;

            return obj = base.Atualizar(obj);
        }
    }
}
