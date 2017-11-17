using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControleJogo.Infra.DatabaseRead.OutputModel;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace ControleJogo.Infra.DatabaseRead.DataAcess
{
    public class JogoFacadeRead : FacadeRead, IJogoDataRead
    {
        public Task<JogoDTO> BuscarPeloId(Guid Id)
        {
            using (IDbConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                return conn.QueryFirstAsync<JogoDTO>("Select * from Jogo where Id = @Id", new { Id = Id });
            }
        }

        public Task<IEnumerable<JogoDTO>> BuscarTodos()
        {
            using (IDbConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                return conn.QueryAsync<JogoDTO>("Select * from Console");
            }
        }
    }
}
