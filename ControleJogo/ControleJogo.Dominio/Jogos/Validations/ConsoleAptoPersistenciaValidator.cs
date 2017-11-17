using ControleJogo.Dominio.Jogos.Entities;
using ControleJogo.Dominio.Jogos.Repositories;
using FluentValidation;

namespace ControleJogo.Dominio.Jogos.Validations
{
    public class ConsoleAptoPersistenciaValidator : AbstractValidator<Console>
    {
        public ConsoleAptoPersistenciaValidator(IConsoleRepository repository)
        {
            RuleFor(t => t.Descricao).CustomAsync(async (descricao, ctx, cacn) =>
            {
                var console = ctx.ParentContext.InstanceToValidate as Console;
                bool valido = !await repository.DescricaoEhUnica(console.Id, descricao);

                if (!valido)
                    ctx.AddFailure(nameof(Console.Descricao), "Descrição já existe cadastrada para outro console!");
            });
        }
    }
}
