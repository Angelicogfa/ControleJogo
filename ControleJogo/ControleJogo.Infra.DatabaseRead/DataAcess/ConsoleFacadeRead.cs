using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControleJogo.Infra.DatabaseRead.OutputModel;
using System.Data.SqlClient;
using Dapper;

namespace ControleJogo.Infra.DatabaseRead.DataAcess
{
    public class ConsoleFacadeRead : FacadeRead, IConsoleDataRead
    {
        public async  Task<ConsoleDTO> BuscarPeloId(Guid Id)
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstAsync<ConsoleDTO>("Select * from Console where Id = @Id", new { Id = Id });
            }
        }

        public async Task<IEnumerable<ConsoleDTO>> BuscarTodos()
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<ConsoleDTO>("Select * from Console");
            }
        }
    }
}
