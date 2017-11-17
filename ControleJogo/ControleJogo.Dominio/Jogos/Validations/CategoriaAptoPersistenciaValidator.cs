using ControleJogo.Dominio.Jogos.Entities;
using ControleJogo.Dominio.Jogos.Repositories;
using FluentValidation;

namespace ControleJogo.Dominio.Jogos.Validations
{
    public class CategoriaAptoPersistenciaValidator : AbstractValidator<Categoria>
    {
        public CategoriaAptoPersistenciaValidator(ICategoriaRepository repository)
        {
            RuleFor(t => t.Descricao).CustomAsync(async (descricao, ctx, cacn) =>
            {
                var categoria = ctx.ParentContext.InstanceToValidate as Categoria;
                bool valido = !await repository.DescricaoEhUnica(categoria.Id, descricao);

                if (!valido)
                    ctx.AddFailure(nameof(Categoria.Descricao), "Descrição já existe cadastrada para outra categoria!");
            });
        }
    }
}
