using ForParty.Models;

namespace ForParty.Repository
{
    public interface IEstoqueRepository
    {
        Task<List<EstoqueDTO>> Estoque();
        Task<bool> ExcluirEstoque(int id);
        Task<EstoqueDTO> ObterItemEstoque(int id);
    }
}