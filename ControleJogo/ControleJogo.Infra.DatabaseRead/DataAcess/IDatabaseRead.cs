using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleJogo.Infra.DatabaseRead.DataAcess
{
    public interface IDatabaseRead<T>
    {
        Task<IEnumerable<T>> BuscarTodos();
        Task<T> BuscarPeloId(Guid Id);
    }
}
