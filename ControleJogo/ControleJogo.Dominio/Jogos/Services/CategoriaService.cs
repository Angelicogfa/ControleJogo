using ControleJogo.Dominio.Jogos.Entities;
using DomainDrivenDesign.Services;
using System;
using ControleJogo.Dominio.Jogos.Repositories;
using ControleJogo.Dominio.Jogos.Validations;

namespace ControleJogo.Dominio.Jogos.Services
{
    public class CategoriaService : Service<Categoria, Guid>, ICategoriaService
    {
        public CategoriaService(ICategoriaRepository repository) : base(repository)
        {
        }

        public override Categoria Adicionar(Categoria obj)
        {
            if (!obj.EhValido())
                return obj;

            obj.ValidationResult = new CategoriaAptoPersistenciaValidator((ICategoriaRepository)_repository).Validate(obj);
            if (!obj.ValidationResult.IsValid)
                return obj;

            return obj = base.Adicionar(obj);
        }

        public override Categoria Atualizar(Categoria obj)
        {
            if (!obj.EhValido())
                return obj;

            obj.ValidationResult = new CategoriaAptoPersistenciaValidator((ICategoriaRepository)_repository).Validate(obj);
            if (!obj.ValidationResult.IsValid)
                return obj;

            return obj = base.Atualizar(obj);
        }
    }
}
