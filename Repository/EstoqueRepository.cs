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
            parametro.Add("@Id", id, DbType.Int32);
            parametro.Add("@Retorno", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            var consulta = @"
                BEGIN TRY
                DELETE
	                [ForParty].[dbo].[Estoque]
                WHERE
	                [Id] = @Id

                SET @Retorno = 1
                END TRY
                BEGIN CATCH
	                SET @Retorno = 0
                END CATCH

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

        public async Task<EditaEstoqueDTO> ObterEditarEstoque(int id)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@Id", id, DbType.Int32);

            var consulta = @"
                SELECT 
                     [Id]
                    ,[Nome]
                    ,[Preco]
                FROM
                    [ForParty].[dbo].[Estoque]
                WHERE
                    [Id] = @Id";

            EditaEstoqueDTO resultado;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Conexao")))
            {
                conn.Open();
                var execute = await conn.QueryAsync<EditaEstoqueDTO>(consulta, parametro);
                resultado = execute.FirstOrDefault();
            }

            return resultado;
        }

        public async Task<bool> EditarEstoque(EditaEstoqueDTO model)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@Id", model.Id, DbType.Int32);
            parametro.Add("@Nome", model.Nome, DbType.String);
            parametro.Add("@Preco", model.Preco, DbType.Decimal);
            parametro.Add("@Retorno", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            var consulta = @"
                BEGIN TRY
                UPDATE
                    [ForParty].[dbo].[Estoque]
	                SET [Nome] = @Nome
                    ,[Preco] = @Preco
                WHERE
	                [Id] = @Id
                SET @Retorno = 1
                END TRY
                BEGIN CATCH
	                SET @Retorno = 0
                END CATCH

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

        public async Task<AdicionarEstoqueDTO> ObterAdicionarEstoque(int id)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@Id", id, DbType.Int32);

            var consulta = @"
                SELECT 
                     [Id]
                    ,[Nome]
                    ,[Quantidade]
                FROM
                    [ForParty].[dbo].[Estoque]
                WHERE
                    [Id] = @Id";

            AdicionarEstoqueDTO resultado;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Conexao")))
            {
                conn.Open();
                var execute = await conn.QueryAsync<AdicionarEstoqueDTO>(consulta, parametro);
                resultado = execute.FirstOrDefault();
            }

            return resultado;
        }

        public async Task<bool> AdicionarEstoque(AdicionarEstoqueDTO model)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@Id", model.Id, DbType.Int32);
            parametro.Add("@QuantidadeAtualizada", model.QuantidadeAtualizada, DbType.String);
            parametro.Add("@Retorno", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            var consulta = @"
                BEGIN TRY
                UPDATE
                    [ForParty].[dbo].[Estoque]
	                SET [Quantidade] = ([Quantidade] + @QuantidadeAtualizada)
                WHERE
	                [Id] = @Id
                SET @Retorno = 1
                END TRY
                BEGIN CATCH
	                SET @Retorno = 0
                END CATCH

                SELECT(@Retorno)";

            bool resultado;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Conexao")))
            {
                conn.Open();
                var execute = await conn.QueryAsync<bool>(consulta, parametro);
                resultado = parametro.Get<bool>("@Retorno");
            }

            return resultado;
        }

        public async Task<bool> AdicionarItemEstoque(AdicionarItemEstoqueDTO model)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@Nome", model.Nome, DbType.String);
            parametro.Add("@Preco", model.Preco, DbType.String);
            parametro.Add("@Quantidade", model.Quantidade, DbType.String);
            parametro.Add("@DataEntrada", model.DataEntrada, DbType.String);
            parametro.Add("@DataVencimento", model.DataVencimento, DbType.String);
            parametro.Add("@Retorno", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            var consulta = @"
                BEGIN TRY
	                INSERT INTO [ForParty].[dbo].[Estoque]
	                ( 
		                 [Nome]
		                ,[Preco]
		                ,[Quantidade]
		                ,[DataEntrada]
		                ,[DataVencimento]
	                )
	                VALUES
	                (
		                 @Nome
		                ,@Preco
		                ,@Quantidade
		                ,@DataEntrada
		                ,@DataVencimento
	                )

	                SET @Retorno = 1
                END TRY
                BEGIN CATCH
	                SET @Retorno = 0
                END CATCH

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
    }
}
