using System.Data;
using System.Data.SqlClient;
using Dapper;
using ForParty.Models;

namespace ForParty.Repository
{
    public class CaixaRepository : ICaixaRepository
    {
        private IConfiguration _configuration;
        public CaixaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ClienteCaixaDTO> VerificarConsumoCaixa(string cpf)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@cpf", cpf, DbType.String);
            var consulta = @"
                SELECT 
                    [ValorTotal] = (
	                    SELECT 
		                    SUM(E.[Preco])
	                    FROM 
		                    [ForParty].[dbo].[Pedido] P 
		                    INNER JOIN [ForParty].[dbo].[Estoque] E ON P.[Pedido] = E.[Nome]
	                    WHERE 
		                    P.[CPF] = @cpf
                    )
                    ,C.[CPF]
                    ,P.[Pedido]
	                ,E.[Preco]
                FROM 
                    [ForParty].[dbo].[Cliente] C
                    INNER JOIN [ForParty].[dbo].[Pedido] P ON C.[CPF] = P.[CPF]
                    INNER JOIN [ForParty].[dbo].[Estoque] E ON P.[Pedido] = E.[Nome]
	            WHERE 
		                C.[CPF] = @cpf
		                AND P.[Pago] = 0";

            var resultado = new ClienteCaixaDTO();
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Conexao")))
            {
                var valorTotal = await conn.QueryAsync<string>(consulta, parametro);
                resultado.ValorTotal = valorTotal.FirstOrDefault();

                resultado.CPF = cpf;

                var consumo = await conn.QueryAsync<CaixaConsumoDTO>(consulta, parametro);
                resultado.Consumo = consumo.ToList();
            }

            return resultado;
        }

        public async Task<bool> ConcluirPagamento(string cpf)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@cpf", cpf, DbType.String);
            parametro.Add("@Retorno", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            var consulta = @"
                BEGIN TRY
	                UPDATE 
		                [ForParty].[dbo].[Cliente]
		                SET [StatusPagamento] = 2
	                WHERE
		                [CPF] = @CPF

	                SET @Retorno = 1
                END TRY
                BEGIN CATCH
	                SET @Retorno = 0
                END CATCH";

            bool resultado;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Conexao")))
            {
                var valorTotal = await conn.QueryAsync<bool>(consulta, parametro);
                resultado = parametro.Get<bool>("@Retorno");
            }

            return resultado;
        }
    }
}
