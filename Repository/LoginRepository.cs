using Dapper;
using ForParty.Models;
using System.Data;
using System.Data.SqlClient;

namespace ForParty.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private IConfiguration _configuration;

        public LoginRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

       
        public async Task<bool> InserirCadastro(string nome, string cpf, string email, string senha)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@Nome", nome, DbType.String);
            parametro.Add("@CPF", cpf, DbType.String);
            parametro.Add("@Email", email, DbType.String);
            parametro.Add("@Senha", senha, DbType.String);
            parametro.Add("@Retorno", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            var criar = @"  
                BEGIN TRY
                    INSERT INTO [ForParty].[dbo].[Cadastro]
                    (
                         [Nome]
                        ,[CPF]
                        ,[Email]
                        ,[Senha]
                    ) 
                    VALUES 
                    (
                         @Nome
                        ,@CPF
                        ,@Email
                        ,@Senha
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
                await conn.QueryAsync(criar, parametro);
                resultado = parametro.Get<bool>("@Retorno");
            }

            return resultado;

        }

        public async Task<bool> VerificarLogin(string email, string senha)
        {
            var parametro = new DynamicParameters();           
            parametro.Add("@Email", email, DbType.String);
            parametro.Add("@Senha", senha, DbType.String);
            parametro.Add("@Resultado", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            var consulta = @"
                DECLARE @Consulta INT

                SET @Consulta = (
                    SELECT
                         COUNT([Id])
                    FROM 
                        [ForParty].[dbo].[Cadastro]
                    WHERE
                        [Email] = @Email
                        AND [Senha] = @Senha
                )

                IF(@Consulta > 0)
                    SET @Resultado = 1
                ELSE
                    SET @Resultado = 0

                SELECT @Resultado";

            bool resultado;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("conexao")))
            {
                conn.Open();
                await conn.QueryAsync(consulta, parametro);
                resultado = parametro.Get<bool>("@Resultado");
                
            }
            return resultado;
        }
    }
}