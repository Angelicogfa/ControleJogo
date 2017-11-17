using System;
using System.Threading.Tasks;
using ControleJogo.Aplicacao.ViewModels;
using DomainDrivenDesign.Repositories;
using ControleJogo.Dominio.Jogos.Services;
using ControleJogo.Dominio.Jogos.Entities;
using AutoMapper;

namespace ControleJogo.Aplicacao.Services
{
    public class JogoAppService : AppServiceBase, IJogoAppService
    {
        readonly IJogoService jogoService;
        public JogoAppService(IUnitOfWork unitOfWork, IJogoService jogoService) : base(unitOfWork)
        {
            this.jogoService = jogoService;
        }

        public async Task<JogoViewModel> Adicionar(JogoViewModel model)
        {
            Jogo jogo = Mapper.Map<JogoViewModel, Jogo>(model);
            jogo = jogoService.Adicionar(jogo);

            if(!jogo.ValidationResult.IsValid)
            {
                model.ValidationResult = model.ValidationResult;
                return model;
            }

            await Commit();
            return Mapper.Map<Jogo, JogoViewModel>(jogo);
        }

        public async Task<JogoViewModel> Atualizar(JogoViewModel model)
        {
            Jogo jogo = Mapper.Map<JogoViewModel, Jogo>(model);
            jogo = jogoService.Atualizar(jogo);

            if (!jogo.ValidationResult.IsValid)
            {
                model.ValidationResult = model.ValidationResult;
                return model;
            }

            await Commit();
            return Mapper.Map<Jogo, JogoViewModel>(jogo);
        }

        public async Task<JogoViewModel> Remover(JogoViewModel model)
        {
            Jogo jogo = Mapper.Map<JogoViewModel, Jogo>(model);
            jogo = jogoService.Remover(jogo);

            if (!jogo.ValidationResult.IsValid)
            {
                model.ValidationResult = model.ValidationResult;
                return model;
            }

            await Commit();
            return Mapper.Map<Jogo, JogoViewModel>(jogo);
        }

        public override void Dispose()
        {
            jogoService.Dispose();
            base.Dispose();
        }
    }
}
