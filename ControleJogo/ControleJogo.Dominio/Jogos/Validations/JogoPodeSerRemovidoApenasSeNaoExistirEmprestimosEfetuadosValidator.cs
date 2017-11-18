using ControleJogo.Dominio.Jogos.Entities;
using ControleJogo.Dominio.Jogos.Repositories;
using FluentValidation;

namespace ControleJogo.Dominio.Jogos.Validations
{
    public class JogoPodeSerRemovidoApenasSeNaoExistirEmprestimosEfetuadosValidator : AbstractValidator<Jogo>
    {
        public JogoPodeSerRemovidoApenasSeNaoExistirEmprestimosEfetuadosValidator(IJogoRepository repository)
        {
            RuleFor(t => t.Nome).CustomAsync(async (Nome, ctx, cacn) =>
            {
                var jogo = ctx.ParentContext.InstanceToValidate as Jogo;
                bool valido = await repository.PossuiEmprestimos(jogo.Id);

                if (valido)
                    ctx.AddFailure(nameof(Jogo.Nome), $"Operação não permitida. O jogo {Nome} possui emprestimos atrelados à ele!");
            });
        }
    }
}
