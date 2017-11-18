using ControleJogo.Dominio.Jogos.Entities;
using ControleJogo.Dominio.Jogos.Repositories;
using FluentValidation;

namespace ControleJogo.Dominio.Jogos.Validations
{
    public class CategoriaPodeSerExcluidoApenasSeNaoTiverJogosValidator : AbstractValidator<Categoria>
    {
        public CategoriaPodeSerExcluidoApenasSeNaoTiverJogosValidator(ICategoriaRepository repository)
        {
            RuleFor(t => t.Descricao).CustomAsync(async (Descricao, ctx, cacn) =>
            {
                var categoria = ctx.ParentContext.InstanceToValidate as Categoria;
                bool valido = await repository.PossuiJogos(categoria.Id);

                if (valido)
                    ctx.AddFailure(nameof(Categoria.Descricao), $"Operação não permitida. A categoria {Descricao} possui jogos atrelados à ela!");
            });
        }
    }
}
