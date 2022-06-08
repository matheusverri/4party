using ForParty.Models;
using ForParty.Repository;

namespace ForParty.Service
{
    public class EstoqueService : IEstoqueService
    {
        private IEstoqueRepository _estoqueRepository;
        public EstoqueService(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        public async Task<List<EstoqueDTO>> Estoque()
        {
            return await _estoqueRepository.Estoque();
        }

        public async Task<bool> ExcluirEstoque(int id)
        {
            return await _estoqueRepository.ExcluirEstoque(id);
        }

        public async Task<EditaEstoqueDTO> ObterEditarEstoque(int id)
        {
            return await _estoqueRepository.ObterEditarEstoque(id);
        }

        public async Task<bool> EditarEstoque(EditaEstoqueDTO model)
        {
            return await _estoqueRepository.EditarEstoque(model);
        }

        public async Task<AdicionarEstoqueDTO> ObterAdicionarEstoque(int id)
        {
            return await _estoqueRepository.ObterAdicionarEstoque(id);
        }

        public async Task<bool> AdicionarEstoque(AdicionarEstoqueDTO model)
        {
            return await _estoqueRepository.AdicionarEstoque(model);
        }

        public async Task<bool> AdicionarItemEstoque(AdicionarItemEstoqueDTO model)
        {
            return await _estoqueRepository.AdicionarItemEstoque(model);
        }
    }
}
