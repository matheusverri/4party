using Dapper;
using ForParty.Models;
using System.Data.SqlClient;

namespace ForParty.Repository
{
    public class EntradaRepository : IEntradaRepository
    {
        private readonly IConfiguration _configuration;
        public EntradaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> InserirEntrada(EntradaDTO model)
        {
            var parametros = new DynamicParameters();
            parametros.Add("", model.Nome);
            parametros.Add("", model.CPF);
            parametros.Add("", model.Idade);
            parametros.Add("", model.Genero);

            var consulta = @"";

            bool resultado;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("conexao")))
            {
                conn.Open();
                var execucao = await conn.QueryAsync<bool>(consulta, parametros);
                resultado = execucao.FirstOrDefault();
            }

            return resultado;
        }

        public async Task<string> VerificarDadosSaida(SaidaDTO model)
        {
            var parametros = new DynamicParameters();
            parametros.Add("", model.Id);

            var consulta = @"";

            string resultado;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("conexao")))
            {
                conn.Open();
                var execucao = await conn.QueryAsync<string>(consulta, parametros);
                resultado = execucao.FirstOrDefault();
            }

            return resultado;
        }
    }
}
