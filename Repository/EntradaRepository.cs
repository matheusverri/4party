using Dapper;
using ForParty.Models;
using System.Data;
using System.Data.SqlClient;

namespace ForParty.Repository
{
    public class EntradaRepository : IEntradaRepository
    {
        private IConfiguration _configuration;
        public EntradaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> InserirEntrada(EntradaDTO model)
        {
            var statusPagamento = 1;

            var parametro = new DynamicParameters();
            parametro.Add("@Nome", model.Nome, DbType.String);
            parametro.Add("@CPF", model.CPF, DbType.String);
            parametro.Add("@Email", model.Email, DbType.String);
            parametro.Add("@Nascimento", model.Nascimento, DbType.String);
            parametro.Add("@Sexo", model.Sexo, DbType.String);
            parametro.Add("@Ingresso", model.Ingresso, DbType.String);
            parametro.Add("@statusPagamento", statusPagamento, DbType.String);
            parametro.Add("@Retorno", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            var insercao = @"
                BEGIN TRY
                    INSERT INTO [ForParty].[dbo].[Cliente]
                    (
                         [Nome]	
                        ,[CPF]	
                        ,[Email]		
                        ,[Nascimento]
                        ,[Sexo]		
                        ,[Ingresso]
                        ,[StatusPagamento]
                        ,[DataHoraEntrada]
                    )
                    VALUES
                    (
                         @Nome
                        ,@CPF
                        ,@Email
                        ,@Nascimento
                        ,@Sexo
                        ,@Ingresso
                        ,@statusPagamento
                        ,GETDATE()
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
                await conn.QueryAsync(insercao, parametro);
                resultado = parametro.Get<bool>("@Retorno");
            }

            return resultado;
        }

        public async Task<SaidaDTO> VerificarDadosSaida(string cpf)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@cpf", cpf, DbType.String);

            var consulta = @"
                SELECT     
	                 C.[Nome]	
	                ,C.[CPF]		
	                ,[HoraEntrada]          = C.[DataHoraEntrada]
	                ,[Status]               = P.[Tipo]
                FROM 
	                [ForParty].[dbo].[Cliente] C
	                INNER JOIN [ForParty].[dbo].[StatusPagamento] P ON P.[Id] = C.[StatusPagamento]
                WHERE 
	                [CPF] = @cpf
	                AND [DataHoraEntrada] IN 
                        (
                            SELECT    
	                            MAX([DataHoraEntrada])
                            FROM 
	                            [ForParty].[dbo].[Cliente]
                            WHERE
	                            [CPF] = @cpf
		                )";

            SaidaDTO resultado;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Conexao")))
            {
                conn.Open();
                var execute = await conn.QueryAsync<SaidaDTO>(consulta, parametro);
                resultado = execute.FirstOrDefault();
            }
            return resultado;
        }

        public async Task<bool> InserirSaidaCliente(string cpf)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@cpf", cpf, DbType.String);
            parametro.Add("@Resultado", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            var consulta = @"
                BEGIN TRY
	                UPDATE
		                [ForParty].[dbo].[Cliente]
		                SET [DataHoraSaida] = GETDATE()
	                WHERE 
		                [CPF] = @cpf
		                AND [DataHoraEntrada] IN 
			                (
				                SELECT    
					                MAX([DataHoraEntrada])
				                FROM 
					                [ForParty].[dbo].[Cliente]
				                WHERE
					                [CPF] = @cpf
			                )

	                SET @Resultado = 1
                END TRY
                BEGIN CATCH
	                SET @Resultado = 0
                END CATCH

                SELECT @Resultado";

            bool resultado;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Conexao")))
            {
                conn.Open();
                var execute = await conn.QueryAsync<bool>(consulta, parametro);
                resultado = parametro.Get<bool>("@Resultado");
            }

            return resultado;
        }
    }
}

