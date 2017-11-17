using System.Threading.Tasks;
using ControleJogo.Aplicacao.ViewModels;
using DomainDrivenDesign.Repositories;
using ControleJogo.Dominio.Amigos.Services;
using ControleJogo.Dominio.Amigos.Entities;
using AutoMapper;

namespace ControleJogo.Aplicacao.Services
{
    public class AmigoAppService : AppServiceBase, IAmigoAppService
    {
        readonly IAmigoService amigoService;
        public AmigoAppService(IUnitOfWork unitOfWork, IAmigoService amigoService) : base(unitOfWork)
        {
            this.amigoService = amigoService;
        }

        public async Task<AmigoViewModel> Adicionar(AmigoViewModel model)
        {
            Amigo amigo = Mapper.Map<AmigoViewModel, Amigo>(model);
            amigo = amigoService.Adicionar(amigo);

            if (!amigo.ValidationResult.IsValid)
            {
                model.ValidationResult = amigo.ValidationResult;
                return model;
            }

            await Commit();
            return Mapper.Map<Amigo, AmigoViewModel>(amigo);
        }

        public async Task<AmigoViewModel> Atualizar(AmigoViewModel model)
        {
            Amigo amigo = Mapper.Map<AmigoViewModel, Amigo>(model);
            amigo = amigoService.Atualizar(amigo);

            if (!amigo.ValidationResult.IsValid)
            {
                model.ValidationResult = amigo.ValidationResult;
                return model;
            }

            await Commit();
            return Mapper.Map<Amigo, AmigoViewModel>(amigo);
        }

        public async Task<AmigoViewModel> Remover(AmigoViewModel model)
        {
            Amigo amigo = Mapper.Map<AmigoViewModel, Amigo>(model);
            amigo = amigoService.Remover(amigo);

            if (!amigo.ValidationResult.IsValid)
            {
                model.ValidationResult = amigo.ValidationResult;
                return model;
            }

            await Commit();
            return Mapper.Map<Amigo, AmigoViewModel>(amigo);
        }

        public override void Dispose()
        {
            amigoService.Dispose();
            base.Dispose();
        }

    }
}
