using ForParty.Models;

namespace ForParty.Repository
{
    public interface IPedidoRepository
    {
        Task<List<PedidoDTO>> Pedido();
        Task<List<ObterProdutoPedidoDTO>> ObterProdutosEstoquePedido();
        Task<bool> AdicionarPedido(string cpf, string nome, string pedido);
        Task<bool> ConcluirPedido(int id);
    }
}
