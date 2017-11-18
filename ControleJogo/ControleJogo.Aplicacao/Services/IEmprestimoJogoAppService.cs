using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace ControleJogo.Aplicacao.Services
{
    public interface IEmprestimoJogoAppService
    {
        Task<ValidationResult> NovoEmprestimo(Guid Jogo, Guid Amigo);
        Task<ValidationResult> DevolverJogoEmprestado(Guid Emprestimo);
        Task<ValidationResult> RenovarJogoEmprestimo(Guid id);
    }
}
