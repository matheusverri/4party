using ForParty.Models;

namespace ForParty.Service
{
    public interface IPedidoService
    {
        Task<List<PedidoDTO>> Pedido();
    }
}
