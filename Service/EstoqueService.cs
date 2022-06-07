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

        public async Task<EstoqueDTO> AdicionarEstoque(int id)
        {
            return await _estoqueRepository.ObterItemEstoque(id);
        }

        public async Task<EstoqueDTO> EditarEstoque(int id)
        {
            return await _estoqueRepository.ObterItemEstoque(id);
        }
    }
}
