using System.Data;
using System.Data.SqlClient;
using Dapper;
using ForParty.Models;

namespace ForParty.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private IConfiguration _configuration;
        public PedidoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<PedidoDTO>> Pedido()
        {
            var consulta = @"
                SELECT
                    [Id]
                    ,[CPF]
                    ,[Nome]
                    ,[HoraEntrada]
                    ,[Pedido]
                    ,[Concluido]
                FROM
                    [ForParty].[dbo].[Pedido]
                WHERE
                    [Concluido] = 0";

            List<PedidoDTO> resultado;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Conexao")))
            {
                conn.Open();
                var execute = await conn.QueryAsync<PedidoDTO>(consulta);
                resultado = execute.ToList();
            }

            return resultado;
        }

        public async Task<List<ObterProdutoPedidoDTO>> ObterProdutosEstoquePedido()
        {
            var consulta = @"
                SELECT 
                     [Nome],
	                 [Preco]
                FROM
                    [ForParty].[dbo].[Estoque]";

            List<ObterProdutoPedidoDTO> resultado;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Conexao")))
            {
                conn.Open();
                var execute = await conn.QueryAsync<ObterProdutoPedidoDTO>(consulta);
                resultado = execute.ToList();
            }

            return resultado;
        }

        public async Task<bool> AdicionarPedido(string cpf, string nome, string pedido)
        {
            var concluido = false;
            var parametro = new DynamicParameters();
            parametro.Add("@CPF", cpf, DbType.String);
            parametro.Add("@Nome", nome, DbType.String);
            parametro.Add("@Pedido", pedido, DbType.String);
            parametro.Add("@Concluido", concluido, DbType.Boolean);
            parametro.Add("@Retorno", dbType: DbType.Boolean, direction: ParameterDirection.Output);
            
            var consulta = @"
                BEGIN TRY
                INSERT INTO [ForParty].[dbo].[Pedido]
                (
	                 [CPF]			
	                ,[Nome]		
	                ,[HoraEntrada]	
	                ,[Pedido]
	                ,[Concluido]
                )
                VALUES
                (
	                 @CPF
	                ,@Nome
	                ,GETDATE()
	                ,@Pedido
	                ,@Concluido
                )

	                SET @Retorno = 1
                END TRY
                BEGIN CATCH
	                SET @Retorno = 0
                END CATCH

                DECLARE @IdItem INT
                IF (@Retorno = 1)
                BEGIN
	                SET @IdItem = 
	                (
		                SELECT 
			                [Id]
		                FROM
			                [ForParty].[dbo].[Estoque]
		                WHERE
			                [Nome] = @Pedido
	                )

	                UPDATE
		                [ForParty].[dbo].[Estoque]
	                SET [Quantidade] = [Quantidade] - 1
	                WHERE
		                [Id] = @IdItem

	                SET @Retorno = 1
                END
                ELSE
                BEGIN
	                SET @Retorno = 0
                END

                SELECT @Retorno";

            bool resultado;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Conexao")))
            {
                conn.Open();
                var execute = await conn.QueryAsync<bool>(consulta, parametro);
                resultado = parametro.Get<bool>("@Retorno");
            }

            return resultado;
        }

        public async Task<bool> ConcluirPedido(int id)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@Id", id, DbType.Int32);
            parametro.Add("@Retorno", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            var consulta = @"
                BEGIN TRY
                UPDATE
                    [ForParty].[dbo].[Pedido]
                    SET [Concluido] = 1
                WHERE
                    [Id] = @Id
	                SET @Retorno = 1
                END TRY
                BEGIN CATCH
	                SET @Retorno = 0
                END CATCH";

            bool resultado;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Conexao")))
            {
                conn.Open();
                var execute = await conn.QueryAsync<bool>(consulta, parametro);
                resultado = parametro.Get<bool>("@Retorno");
            }

            return resultado;
        }
    }
}
