using ForParty.Models;
using ForParty.Repository;

namespace ForParty.Service
{
    public class AdministracaoService : IAdministracaoService
    {

        private IAdministracaoRepository _administracaoRepository;
        public AdministracaoService(IAdministracaoRepository administracaoRepository)
        {
            _administracaoRepository = administracaoRepository;
        }

        public async Task<List<AdministracaoDTO>> VerificarDadosAnalise()
        {
            return await _administracaoRepository.VerificarDadosAnalise();
        }
    }
}
