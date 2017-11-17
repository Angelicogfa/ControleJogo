using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControleJogo.Infra.DatabaseRead.OutputModel;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace ControleJogo.Infra.DatabaseRead.DataAcess
{
    public class CategoriaFacadeRead : FacadeRead, ICategoriaDataRead
    {
        public Task<CategoriaDTO> BuscarPeloId(Guid Id)
        {
            using (IDbConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                return conn.QueryFirstAsync<CategoriaDTO>("Select * from Categoria where Id = @Id", new { Id = Id });
            }
        }

        public Task<IEnumerable<CategoriaDTO>> BuscarTodos()
        {
            using (IDbConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                return conn.QueryAsync<CategoriaDTO>("Select * from Categoria");
            }
        }
    }
}
