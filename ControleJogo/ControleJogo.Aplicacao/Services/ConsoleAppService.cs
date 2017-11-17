using System.Threading.Tasks;
using ControleJogo.Aplicacao.InputModel;
using DomainDrivenDesign.Repositories;
using ControleJogo.Dominio.Jogos.Services;
using AutoMapper;
using ControleJogo.Dominio.Jogos.Entities;

namespace ControleJogo.Aplicacao.Services
{
    public class ConsoleAppService : AppServiceBase, IConsoleAppService
    {
        readonly IConsoleService consoleService;
        public ConsoleAppService(IUnitOfWork unitOfWork, IConsoleService consoleService) : base(unitOfWork)
        {
            this.consoleService = consoleService;
        }

        public async Task<ConsoleViewModel> Adicionar(ConsoleViewModel model)
        {
            var console = Mapper.Map<ConsoleViewModel, Console>(model);
            console = consoleService.Adicionar(console);

            if(!console.ValidationResult.IsValid)
            {
                model.ValidationResult = console.ValidationResult;
                return model;
            }

            await Commit();
            return Mapper.Map<Console, ConsoleViewModel>(console);
        }

        public async Task<ConsoleViewModel> Atualizar(ConsoleViewModel model)
        {
            var console = Mapper.Map<ConsoleViewModel, Console>(model);
            console = consoleService.Atualizar(console);

            if (!console.ValidationResult.IsValid)
            {
                model.ValidationResult = console.ValidationResult;
                return model;
            }

            await Commit();
            return Mapper.Map<Console, ConsoleViewModel>(console);
        }

        public async Task<ConsoleViewModel> Remover(ConsoleViewModel model)
        {
            var console = Mapper.Map<ConsoleViewModel, Console>(model);
            console = consoleService.Remover(console);

            if (!console.ValidationResult.IsValid)
            {
                model.ValidationResult = console.ValidationResult;
                return model;
            }

            await Commit();
            return Mapper.Map<Console, ConsoleViewModel>(console);
        }

        public override void Dispose()
        {
            consoleService.Dispose();
            base.Dispose();
        }
    }
}
