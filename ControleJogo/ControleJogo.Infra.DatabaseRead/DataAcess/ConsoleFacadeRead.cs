using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControleJogo.Infra.DatabaseRead.OutputModel;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace ControleJogo.Infra.DatabaseRead.DataAcess
{
    public class ConsoleFacadeRead : FacadeRead, IConsoleDataRead
    {
        public Task<ConsoleDTO> BuscarPeloId(Guid Id)
        {
            using (IDbConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                return conn.QueryFirstAsync<ConsoleDTO>("Select * from Console where Id = @Id", new { Id = Id });
            }
        }

        public Task<IEnumerable<ConsoleDTO>> BuscarTodos()
        {
            using (IDbConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                return conn.QueryAsync<ConsoleDTO>("Select * from Console");
            }
        }
    }
}
