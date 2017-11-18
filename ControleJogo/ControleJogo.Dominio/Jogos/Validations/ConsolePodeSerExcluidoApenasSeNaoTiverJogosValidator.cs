using ControleJogo.Dominio.Jogos.Entities;
using ControleJogo.Dominio.Jogos.Repositories;
using FluentValidation;

namespace ControleJogo.Dominio.Jogos.Validations
{
    public class ConsolePodeSerExcluidoApenasSeNaoTiverJogosValidator : AbstractValidator<Console>
    {
        public ConsolePodeSerExcluidoApenasSeNaoTiverJogosValidator(IConsoleRepository repository)
        {
            RuleFor(t => t.Descricao).CustomAsync(async (Descricao, ctx, cacn) =>
            {
                var console = ctx.ParentContext.InstanceToValidate as Console;
                bool valido = await repository.PossuiJogos(console.Id);

                if (valido)
                    ctx.AddFailure(nameof(Console.Descricao), $"Operação não permitida. O console {Descricao} possui jogos atrelados à ele!");
            });
        }
    }
}
