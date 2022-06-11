using ForParty.Models;
using ForParty.Repository;

namespace ForParty.Service
{
    public class CaixaService : ICaixaService
    {
        private ICaixaRepository _caixaRepository;

        public CaixaService(ICaixaRepository caixaRepository)
        {
            _caixaRepository = caixaRepository;
        }

        public async Task<ClienteCaixaDTO> VerificarConsumoCaixa(string cpf)
        {
            return await _caixaRepository.VerificarConsumoCaixa(cpf);
        }

        public async Task<bool> ConcluirPagamento(string cpf)
        {
            return await _caixaRepository.ConcluirPagamento(cpf);
        }
    }
}
