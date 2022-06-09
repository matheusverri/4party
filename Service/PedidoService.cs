using ForParty.Models;
using ForParty.Repository;

namespace ForParty.Service
{
    public class PedidoService : IPedidoService
    {
        private IPedidoRepository _pedidoService;

        public PedidoService(IPedidoRepository pedidoService)
        {
            _pedidoService = pedidoService;
        }

        public async Task<List<PedidoDTO>> Pedido()
        {
            return await _pedidoService.Pedido();
        }

        public async Task<List<ObterProdutoPedidoDTO>> ObterProdutosEstoquePedido()
        {
            return await _pedidoService.ObterProdutosEstoquePedido();
        }
        
        public async Task<bool> AdicionarPedido(string cpf, string nome, string pedido)
        {
            return await _pedidoService.AdicionarPedido(cpf, nome, pedido);
        }

        public async Task<bool> ConcluirPedido(int id)
        {
            return await _pedidoService.ConcluirPedido(id);
        }
    }
}
