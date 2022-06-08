using ForParty.Models;

namespace ForParty.Repository
{
    public interface IEstoqueRepository
    {
        Task<List<EstoqueDTO>> Estoque();
        Task<bool> ExcluirEstoque(int id);
        Task<EditaEstoqueDTO> ObterEditarEstoque(int id);
        Task<bool> EditarEstoque(EditaEstoqueDTO model);
        Task<AdicionarEstoqueDTO> ObterAdicionarEstoque(int id);
        Task<bool> AdicionarEstoque(AdicionarEstoqueDTO model);
        Task<bool> AdicionarItemEstoque(AdicionarItemEstoqueDTO model);
    }
}