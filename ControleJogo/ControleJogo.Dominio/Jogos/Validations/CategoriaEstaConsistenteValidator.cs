using ControleJogo.Dominio.Jogos.Entities;
using FluentValidation;

namespace ControleJogo.Dominio.Jogos.Validations
{
    public class CategoriaEstaConsistenteValidator : AbstractValidator<Categoria>
    {
        public CategoriaEstaConsistenteValidator()
        {
            RuleFor(t => t.Descricao)
               .NotNull().WithMessage("Descrição não informado!")
               .NotEmpty().WithMessage("Descrição não informado!")
               .MinimumLength(3).WithMessage("Descrição deve ter no mínimo 3 caractéres!")
               .MaximumLength(50).WithMessage("Descrição deve ter no máximo 50 caractéres!");               
        }
    }
}
