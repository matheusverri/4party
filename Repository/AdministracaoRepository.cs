using Dapper;
using ForParty.Models;
using System.Data;
using System.Data.SqlClient;

namespace ForParty.Repository
{
    public class AdministracaoRepository : IAdministracaoRepository
    {
        private IConfiguration _configuration;
        public AdministracaoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<AdministracaoDTO>> VerificarDadosAnalise()
        {
            var consulta = @"
                SELECT    
	                 C.[CPF]		
	                ,[HoraEntrada]      = C.[DataHoraEntrada]
                    ,[HoraSaida]        = C.[DataHoraSaida]
                    ,[Sexo]             = S.[Tipo]
                FROM 
	                [ForParty].[dbo].[Cliente] C
	                INNER JOIN [ForParty].[dbo].[Sexo] S ON S.[Id] = C.[Sexo]";

            List<AdministracaoDTO> resultado;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Conexao")))
            {
                conn.Open();
                var execute = await conn.QueryAsync<AdministracaoDTO>(consulta);
                resultado = execute.ToList();
            }
            return resultado;
        }
    }
}
