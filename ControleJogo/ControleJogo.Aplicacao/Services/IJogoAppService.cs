using ControleJogo.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleJogo.Aplicacao.Services
{
    public interface  IJogoAppService : IDisposable
    {
        Task<JogoViewModel> Adicionar(JogoViewModel model);
        Task<JogoViewModel> Atualizar(JogoViewModel model);
        Task<JogoViewModel> Remover(JogoViewModel model);
    }
}
