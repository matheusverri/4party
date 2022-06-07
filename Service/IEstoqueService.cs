using ForParty.Models;

namespace ForParty.Service
{
    public interface IEstoqueService
    {
        Task<List<EstoqueDTO>> Estoque();
        Task<bool> ExcluirEstoque(int id);
        Task<EstoqueDTO> AdicionarEstoque(int id);
        Task<EstoqueDTO> EditarEstoque(int id);
    }
}