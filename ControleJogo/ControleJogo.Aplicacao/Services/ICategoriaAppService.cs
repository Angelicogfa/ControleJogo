using ControleJogo.Aplicacao.ViewModels;
using System;
using System.Threading.Tasks;

namespace ControleJogo.Aplicacao.Services
{
    public interface ICategoriaAppService : IDisposable
    {
        Task<CategoriaViewModel> Adicionar(CategoriaViewModel model);
        Task<CategoriaViewModel> Atualizar(CategoriaViewModel model);
        Task<CategoriaViewModel> Remover(CategoriaViewModel model);
    }
}
