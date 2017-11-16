using ControleJogo.Dominio.Amigos.Entities;
using FluentValidation;
using System.Linq;

namespace ControleJogo.Dominio.Amigos.Validations
{
    public class AmigoEstaConsistenteValidator : AbstractValidator<Amigo>
    {
        public AmigoEstaConsistenteValidator()
        {
            RuleFor(t => t.Nome)
                .NotNull().WithMessage("Nome não informado!")
                .NotEmpty().WithMessage("Nome não informado!")
                .MinimumLength(3).WithMessage("Nome deve ter no mínimo 3 caractéres!")
                .MaximumLength(50).WithMessage("Nome deve ter no máximo 50 caractéres!");

            RuleFor(t => t.Email)
                .NotNull().WithMessage("Email não informado!")
                .Custom((email, ctx) => 
                {
                    if(!email.EhValido())
                        email.ValidationResult.Errors.ToList().ForEach(t => ctx.AddFailure(t));
                });

            RuleFor(t => t.Logradouro)
               .NotNull().WithMessage("Logradouro não informado!")
               .Custom((logradouro, ctx)=> 
               {
                   if(!logradouro.EhValido())
                       logradouro.ValidationResult.Errors.ToList().ForEach(t => ctx.AddFailure(t));
               });
        }
    }
}
