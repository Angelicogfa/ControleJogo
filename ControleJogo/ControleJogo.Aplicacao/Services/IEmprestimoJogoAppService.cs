using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace ControleJogo.Aplicacao.Services
{
    public interface IEmprestimoJogoAppService
    {
        Task<ValidationResult> NovoEmprestimo(Guid Jogo, Guid Amigo);
        Task<ValidationResult> AtualizarStatusEmprestimo(Guid Emprestimo, bool Devolvido);
    }
}
