using ControleJogo.Dominio.Jogos.Entities;
using ControleJogo.Dominio.Jogos.Repositories;
using FluentValidation;

namespace ControleJogo.Dominio.Jogos.Validations
{
    public class JogoEstaAptoPersistenciaValidator : AbstractValidator<Jogo>
    {
        public JogoEstaAptoPersistenciaValidator(IJogoRepository repository)
        {
            RuleFor(t => t.Nome).CustomAsync(async (nome, ctx, cacn) =>
            {
                var jogo = ctx.ParentContext.InstanceToValidate as Jogo;
                bool valido = !await repository.NomeEhUnicoPorConsole(jogo.Id, jogo.ConsoleId, nome);

                if (!valido)
                    ctx.AddFailure(nameof(Jogo.Nome), "Nome do jogo já existe cadastrada para o console!");
            });
        }
    }
}
