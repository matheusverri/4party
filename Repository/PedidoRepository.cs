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
                    ,[Nome]
                    ,[Preco]
                    ,[Quantidade]
                    ,[DataEntrada]
                    ,[DataVencimento]
                FROM
                    [ForParty].[dbo].[Estoque]";

            List<PedidoDTO> resultado;
            using (var conn = new SqlConnection(_configuration.GetConnectionString("Conexao")))
            {
                conn.Open();
                var execute = await conn.QueryAsync<PedidoDTO>(consulta);
                resultado = execute.ToList();
            }

            return resultado;
        }
    }
}
