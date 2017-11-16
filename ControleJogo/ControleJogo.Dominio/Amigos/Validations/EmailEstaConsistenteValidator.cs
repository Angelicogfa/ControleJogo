using ControleJogo.Dominio.Amigos.ObejctValues;
using FluentValidation;

namespace ControleJogo.Dominio.Amigos.Validations
{
    public class EmailEstaConsistenteValidator : AbstractValidator<Email>
    {
        public EmailEstaConsistenteValidator()
        {
            RuleFor(t => t.Value)
                .NotNull().WithMessage("Email não informado!")
                .NotEmpty().WithMessage("Email não informado!")
                .EmailAddress().WithMessage("Email informado é inválido!");
        }
    }
}
