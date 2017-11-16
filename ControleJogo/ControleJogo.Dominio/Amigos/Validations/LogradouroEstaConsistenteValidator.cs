using ControleJogo.Dominio.Amigos.ObejctValues;
using FluentValidation;
using System.Text.RegularExpressions;

namespace ControleJogo.Dominio.Amigos.Validations
{
    public class LogradouroEstaConsistenteValidator : AbstractValidator<Logradouro>
    {
        public LogradouroEstaConsistenteValidator()
        {
            RuleFor(t => t.Estado)
                .IsInEnum().WithMessage("Estado não informado!");

            RuleFor(t => t.CEP)
                .NotNull().WithMessage("CEP não informado!")
                .NotEmpty().WithMessage("CEP não informado!")
                .MaximumLength(9).WithMessage("CEP deve ter 9 caractéres!")
                .MinimumLength(9).WithMessage("CEP deve ter 9 caractéres!")
                .Must(t =>
                {
                    return Regex.IsMatch(t, "[0-9]{5}-[0-9]{3}");
                }).WithMessage("O CEP deve possuir a mascara xxxxx-xxx");

            RuleFor(t => t.Bairro)
                .NotNull().WithMessage("Bairro não informado!")
                .NotEmpty().WithMessage("Bairro não informado!")
                .MinimumLength(2).WithMessage("Bairro deve ter no mínimo 2 caractéres!")
                .MaximumLength(50).WithMessage("Bairro deve ter no máximo 50 caractéres!");

            RuleFor(t => t.Endereco)
                .NotNull().WithMessage("Endereco não informado!")
                .NotEmpty().WithMessage("Endereco não informado!")
                .MinimumLength(2).WithMessage("Endereco deve ter no mínimo 2 caractéres!")
                .MaximumLength(50).WithMessage("Endereco deve ter no máximo 50 caractéres!");

            RuleFor(t => t.Numero)
                .NotNull().WithMessage("Numero não informado!")
                .NotEmpty().WithMessage("Numero não informado!")
                .MinimumLength(1).WithMessage("Numero deve ter no mínimo 1 caractér!")
                .MaximumLength(10).WithMessage("Numero deve ter no máximo 10 caractéres!");

            RuleFor(t => t.Complemento)
               .MaximumLength(30).WithMessage("Complemento deve ter no máximo 30 caractéres!");
        }
    }
}
