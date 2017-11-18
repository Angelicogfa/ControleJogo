using ControleJogo.Dominio.Jogos.Entities;
using FluentValidation;
using System;

namespace ControleJogo.Dominio.Jogos.Validations
{
    public class JogoEstaConsistenteValidator : AbstractValidator<Jogo>
    {
        public JogoEstaConsistenteValidator()
        {
            RuleFor(t => t.Nome)
                .NotNull().WithMessage("Nome não informado!")
                .NotEmpty().WithMessage("Nome não informado!")
                .MinimumLength(3).WithMessage("Nome deve ter no mínimo 3 caractéres!")
                .MaximumLength(50).WithMessage("Nome deve ter no máximo 50 caractéres!");

            RuleFor(t => t.CategoriaId)
                .NotNull().WithMessage("Categoria não informada!")
                .Must(t => t != Guid.Empty).WithMessage("Categoria não informada!");

            RuleFor(t => t.ConsoleId)
                .NotNull().WithMessage("Console não informado!")
                .Must(t => t != Guid.Empty).WithMessage("Console não informado!");

            RuleFor(t => t.QuantidadeJogos)
                .GreaterThanOrEqualTo(0).WithMessage("Quantidade informada é inválida! Apenas valores positivos são permitidos");
        }
    }
}
