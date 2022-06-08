using ForParty.Models;

namespace ForParty.Repository
{
    public interface IPedidoRepository
    {
        Task<List<PedidoDTO>> Pedido();
    }
}
