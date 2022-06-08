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
    }
}
