using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControleJogo.Infra.DatabaseRead.OutputModel;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace ControleJogo.Infra.DatabaseRead.DataAcess
{
    public class AmigoFacadeRead : FacadeRead, IAmigoDataRead
    {
        public Task<AmigoDTO> BuscarPeloId(Guid Id)
        {
            using (IDbConnection conn = new SqlConnection(conexao))
            {
                return conn.QueryFirstAsync<AmigoDTO>("Select * from Amigo where Id = @Id", new { Id = Id});
            }
        }

        public Task<IEnumerable<AmigoDTO>> BuscarTodos()
        {
            using (IDbConnection conn = new SqlConnection(conexao))
            {
                return conn.QueryAsync<AmigoDTO>("Select * from Amigo");
            }
        }
    }
}
