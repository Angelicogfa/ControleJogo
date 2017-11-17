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
        public async Task<AmigoDTO> BuscarPeloId(Guid Id)
        {
            using (IDbConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                return await conn.QueryFirstAsync<AmigoDTO>("Select * from Amigo where Id = @Id", new { Id = Id});
            }
        }

        public async Task<IEnumerable<AmigoDTO>> BuscarTodos()
        {
            using (IDbConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                return await conn.QueryAsync<AmigoDTO>("Select * from Amigo");
            }
        }
    }
}
