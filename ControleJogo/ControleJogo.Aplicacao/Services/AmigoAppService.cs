using System.Threading.Tasks;
using ControleJogo.Aplicacao.InputModel;
using DomainDrivenDesign.Repositories;
using ControleJogo.Dominio.Amigos.Services;
using ControleJogo.Dominio.Amigos.Entities;
using AutoMapper;
using System;

namespace ControleJogo.Aplicacao.Services
{
    public class AmigoAppService : AppServiceBase, IAmigoAppService
    {
        readonly IAmigoService amigoService;

        public object Enummodel { get; private set; }

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
            Amigo amigo = await amigoService.ProcurarPeloId(model.Id);

            amigo.AlterarNome(model.Nome);
            amigo.AlterarEmail(model.Email);
            amigo.AlterarLogradouro(new Dominio.Amigos.ObejctValues.Logradouro((Dominio.Amigos.ObejctValues.Estado)Enum.ToObject(typeof(Dominio.Amigos.ObejctValues.Estado), (int) model.Estado), model.CEP, model.Cidade,model.Bairro, model.Endereco, model.Numero, model.Complemento));

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
