using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControleJogo.Infra.DatabaseRead.OutputModel;
using System.Data.SqlClient;
using Dapper;
using System.Text;

namespace ControleJogo.Infra.DatabaseRead.DataAcess
{
    public class EmprestimoJogoFacadeRead : FacadeRead, IEmprestimoJogoDataRead
    {
        private string ObterQueryEmprestimo(bool InformaId)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select TOP 10 emp.Id, emp.JogoId, j.Nome NomeJogo, emp.AmigoId,");
            sql.AppendLine(" a.Nome NomeAmigo, emp.DataEmprestimo, emp.DataDevolucao, emp.Devolvido");
            sql.AppendLine(" from EmprestimoJogo emp");
            sql.AppendLine(" inner join Jogo j on emp.JogoId = j.Id");
            sql.AppendLine(" inner join Amigo a on emp.AmigoId = a.Id");

            if (InformaId)
                sql.AppendLine(" where emp.Id = @Id");

            sql.AppendLine(" order by emp.DataEmprestimo desc");

            return sql.ToString();
        }

        private string ObterQueryParaAmigo()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select emp.Id, emp.JogoId, j.Nome NomeJogo, emp.AmigoId,");
            sql.AppendLine(" a.Nome NomeAmigo, emp.DataEmprestimo, emp.DataDevolucao, emp.Devolvido");
            sql.AppendLine(" from EmprestimoJogo emp");
            sql.AppendLine(" inner join Jogo j on emp.JogoId = j.Id");
            sql.AppendLine(" inner join Amigo a on emp.AmigoId = a.Id");

            sql.AppendLine(" where a.Id = @Id");

            sql.AppendLine(" order by emp.DataEmprestimo desc");

            return sql.ToString();
        }

        private string ObterQueryParaJogo()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select emp.Id, emp.JogoId, j.Nome NomeJogo, emp.AmigoId,");
            sql.AppendLine(" a.Nome NomeAmigo, emp.DataEmprestimo, emp.DataDevolucao, emp.Devolvido");
            sql.AppendLine(" from EmprestimoJogo emp");
            sql.AppendLine(" inner join Jogo j on emp.JogoId = j.Id");
            sql.AppendLine(" inner join Amigo a on emp.AmigoId = a.Id");

            sql.AppendLine(" where j.Id = @Id");

            sql.AppendLine(" order by emp.DataEmprestimo desc");

            return sql.ToString();
        }

        public async Task<EmprestimoDTO> BuscarPeloId(Guid Id)
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstAsync<EmprestimoDTO>(ObterQueryEmprestimo(true), new { Id = Id });
            }
        }

        public async Task<IEnumerable<EmprestimoDTO>> BuscarTodos()
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<EmprestimoDTO>(ObterQueryEmprestimo(false));
            }
        }

        public async Task<IEnumerable<EmprestimoDTO>> BuscarTodosParaJogo(Guid Id)
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<EmprestimoDTO>(ObterQueryParaJogo(), new { Id = Id });
            }
        }

        public async Task<IEnumerable<EmprestimoDTO>> BuscarTodosParaAmigo(Guid Id)
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<EmprestimoDTO>(ObterQueryParaAmigo(), new { Id = Id });
            }
        }
      
        public async Task<IEnumerable<TopEmprestados>> TopMaisEmprestados()
        {
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("select TOP 5 j.Id JogoId, j.Nome NomeJogo, COUNT(emp.Id) QuantidadeEmprestimos");
                sql.AppendLine(" from EmprestimoJogo emp");
                sql.AppendLine(" inner join Jogo j on emp.JogoId = j.Id");
                sql.AppendLine(" group by emp.JogoId, j.Id, j.Nome");

                await conn.OpenAsync();
                return await conn.QueryAsync<TopEmprestados>(sql.ToString());
            }
        }

        public async Task<IEnumerable<EmprestimoDTO>> BuscarTodosParaJogoAmigo(Guid? Amigo, Guid? Jogo, bool? Devolvido)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select TOP 10 emp.Id, emp.JogoId, j.Nome NomeJogo, emp.AmigoId,");
            sql.AppendLine(" a.Nome NomeAmigo, emp.DataEmprestimo, emp.DataDevolucao, emp.Devolvido");
            sql.AppendLine(" from EmprestimoJogo emp");
            sql.AppendLine(" inner join Jogo j on emp.JogoId = j.Id");
            sql.AppendLine(" inner join Amigo a on emp.AmigoId = a.Id");

            if(Amigo.HasValue || Jogo.HasValue || Devolvido.HasValue)
            {
                sql.AppendLine(" where ");

                if(Amigo.HasValue)
                    sql.Append($" a.Id = '{Amigo}' and");

                if (Jogo.HasValue)
                    sql.Append($" j.Id = '{Jogo}' and");

                if(Devolvido.HasValue)
                    sql.Append($" emp.Devolvido = '{Devolvido}' ");

                int lastIndex = sql.ToString().LastIndexOf("and");
                if (lastIndex > -1)
                    sql = new StringBuilder(sql.ToString().Substring(0, lastIndex));
            }
            sql.AppendLine(" order by emp.DataEmprestimo desc");

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<EmprestimoDTO>(sql.ToString());
            }
        }
    }
}
