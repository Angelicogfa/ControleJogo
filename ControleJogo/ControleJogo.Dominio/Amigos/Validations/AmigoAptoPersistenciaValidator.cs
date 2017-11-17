using ControleJogo.Dominio.Amigos.Entities;
using ControleJogo.Dominio.Amigos.Repositories;
using FluentValidation;

namespace ControleJogo.Dominio.Amigos.Validations
{
    public class AmigoAptoPersistenciaValidator : AbstractValidator<Amigo>
    {
        public AmigoAptoPersistenciaValidator(IAmigoRepository amigoRepository) 
        {
            RuleFor(t => t.Email).CustomAsync(async(email, ctx, cacn) => 
            {
                var amigo = ctx.ParentContext.InstanceToValidate as Amigo;
                bool valido = await amigoRepository.EmailEhUnico(amigo.Id, email);

                if (!valido)
                    ctx.AddFailure(nameof(Amigo.Email), "Email informado já cadastrado para outro amigo!");
            });
        }
    }
}
