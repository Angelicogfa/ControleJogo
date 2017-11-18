using ControleJogo.Infra.DatabaseRead.OutputModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleJogo.Infra.DatabaseRead.DataAcess
{
    public interface IEmprestimoJogoDataRead : IDatabaseRead<EmprestimoDTO>
    {
        Task<IEnumerable<EmprestimoDTO>> BuscarTodosParaJogo(Guid Id);
        Task<IEnumerable<EmprestimoDTO>> BuscarTodosParaAmigo(Guid Id);
        Task<IEnumerable<TopEmprestados>> TopMaisEmprestados();
        Task<IEnumerable<EmprestimoDTO>> BuscarTodosParaJogoAmigo(Guid? Amigo, Guid? Jogo);
    }
}
