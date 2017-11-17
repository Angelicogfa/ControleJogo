using ControleJogo.Aplicacao.ViewModels;
using System;
using System.Threading.Tasks;

namespace ControleJogo.Aplicacao.Services
{
    public interface IConsoleAppService : IDisposable
    {
        Task<ConsoleViewModel> Adicionar(ConsoleViewModel model);
        Task<ConsoleViewModel> Atualizar(ConsoleViewModel model);
        Task<ConsoleViewModel> Remover(ConsoleViewModel model);
    }
}
