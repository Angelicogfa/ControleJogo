using ControleJogo.Dominio.Amigos.Entities;
using ControleJogo.Dominio.Amigos.Repositories;
using FluentValidation;

namespace ControleJogo.Dominio.Amigos.Validations
{
    public class AmigoPodeSerExcluidoApenasSeNaoTiverEmprestimosValidator : AbstractValidator<Amigo>
    {
        public AmigoPodeSerExcluidoApenasSeNaoTiverEmprestimosValidator(IAmigoRepository amigoRepository)
        {
            RuleFor(t => t.Nome).CustomAsync(async (Nome, ctx, cacn) =>
            {
                var amigo = ctx.ParentContext.InstanceToValidate as Amigo;
                bool valido = await amigoRepository.PossuiEmprestimos(amigo.Id);

                if (valido)
                    ctx.AddFailure(nameof(Amigo.Nome), $"Operação não permitida. O amigo {Nome} possui emprestimos efetuados!");
            });
        }
    }
}
