using ControleJogo.Dominio.Amigos.Entities;
using ControleJogo.Dominio.Amigos.Repositories;
using FluentValidation;

namespace ControleJogo.Dominio.Amigos.Validations
{
    public class AmigoPodeSerExcluidoApenasSeNaoTiverEmprestimosValidator : AbstractValidator<Amigo>
    {
        public AmigoPodeSerExcluidoApenasSeNaoTiverEmprestimosValidator(IAmigoRepository amigoRepository)
        {
            RuleFor(t => t.Id).CustomAsync(async (Id, ctx, cacn) =>
            {
                var amigo = ctx.ParentContext.InstanceToValidate as Amigo;
                bool valido = !await amigoRepository.PossuiEmprestimos(Id);

                if (valido)
                    ctx.AddFailure(nameof(Amigo.Id), $"Operação não permitida. O amigo {amigo.Nome} possui emprestimos efetuados!");
            });
        }
    }
}
