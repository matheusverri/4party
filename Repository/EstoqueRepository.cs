using System.Data;
using System.Data.SqlClient;
using Dapper;
using ForParty.Models;

namespace ForParty.Repository
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private IConfiguration _configuration;
        public EstoqueRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<EstoqueDTO>> Estoque()
        {
            var consulta = @"
                SELECT 
                     [Id]
                    ,[Nome]
                    ,[Preco]
                    ,[Quantidade]
                    ,[DataEntrada]
                    ,[DataVencimento]
                FROM
                    [ForParty].[dbo].[Estoque]";

            List<EstoqueDTO> resultado;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Conexao")))
            {
                conn.Open();
                var execute = await conn.QueryAsync<EstoqueDTO>(consulta);
                resultado = execute.ToList();
            }

            return resultado;
        }

        public async Task<bool> ExcluirEstoque(int id)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@id", id, DbType.Int32);
            parametro.Add("@Retorno", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            var consulta = @"
                ";

            bool resultado;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Conexao")))
            {
                conn.Open();
                var execute = await conn.QueryAsync<bool>(consulta, parametro);
                resultado = parametro.Get<bool>("@Retorno");
            }

            return resultado;
        }

        public async Task<EstoqueDTO> ObterItemEstoque(int id)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@id", id, DbType.Int32);
            parametro.Add("@Retorno", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            var consulta = @"
                ";

            EstoqueDTO  resultado;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Conexao")))
            {
                conn.Open();
                var execute = await conn.QueryAsync<EstoqueDTO>(consulta, parametro);
                resultado = execute.FirstOrDefault();
            }

            return resultado;
        }
    }
}
