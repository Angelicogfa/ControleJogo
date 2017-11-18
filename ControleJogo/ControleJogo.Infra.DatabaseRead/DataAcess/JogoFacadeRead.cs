using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControleJogo.Infra.DatabaseRead.OutputModel;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Text;

namespace ControleJogo.Infra.DatabaseRead.DataAcess
{
    public class JogoFacadeRead : FacadeRead, IJogoDataRead
    {
        private string ObterSql(bool PesquisaId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("Select j.Id Id,");
            sql.AppendLine(" j.Nome Nome,");
            sql.AppendLine(" j.CategoriaId CategoriaId,");
            sql.AppendLine(" cat.Descricao DescricaoCategoria,");
            sql.AppendLine(" j.ConsoleId ConsoleId,");
            sql.AppendLine(" con.Descricao DescricaoConsole,");
            sql.AppendLine(" j.Indisponivel Indisponivel,");
            sql.AppendLine(" j.QuantidadeJogos QuantidadeJogos");
            sql.AppendLine(" from Jogo j");
            sql.AppendLine(" inner join Categoria cat on j.CategoriaId = cat.Id");
            sql.AppendLine(" inner join Console con on j.ConsoleId = con.Id");

            if (PesquisaId)
                sql.AppendFormat(" where j.Id = @Id");

            return sql.ToString();
        }

        public async Task<JogoDTO> BuscarPeloId(Guid Id)
        {
            using (IDbConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                return await conn.QueryFirstAsync<JogoDTO>(ObterSql(true), new { Id = Id});
            }
        }

        public async Task<IEnumerable<JogoDTO>> BuscarTodos()
        {
            using (IDbConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                return await conn.QueryAsync<JogoDTO>(ObterSql(false));
            }
        }

        public async Task<byte[]> CarregarImagem(Guid Id)
        {
            using (IDbConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                var bytes = await conn.QueryFirstAsync<byte[]>("Select FotoJogo from Jogo where Id = @Id", new { Id = Id });
                return bytes;
            }
        }
    }
}
