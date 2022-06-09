using ForParty.Models;

namespace ForParty.Service
{
    public interface IPedidoService
    {
        Task<List<PedidoDTO>> Pedido();
        Task<List<ObterProdutoPedidoDTO>> ObterProdutosEstoquePedido();
        Task<bool> AdicionarPedido(string cpf, string nome, string pedido);
        Task<bool> ConcluirPedido(int id);
    }
}
