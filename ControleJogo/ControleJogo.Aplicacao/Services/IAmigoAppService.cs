using ControleJogo.Aplicacao.ViewModels;
using System;
using System.Threading.Tasks;

namespace ControleJogo.Aplicacao.Services
{
    public interface IAmigoAppService : IDisposable
    {
        Task<AmigoViewModel> Adicionar(AmigoViewModel model);
        Task<AmigoViewModel> Atualizar(AmigoViewModel model);
        Task<AmigoViewModel> Remover(AmigoViewModel model);
    }
}
