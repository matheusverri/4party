using ForParty.Models;
using ForParty.Repository;

namespace ForParty.Service
{
    public class EntradaService : IEntradaService
    {
        private readonly IEntradaRepository _entradaRepository;

        public EntradaService(IEntradaRepository entradaRepository)
        {
            _entradaRepository = entradaRepository;
        }

        public async Task<bool> InserirEntrada(EntradaDTO model)
        {
            return await _entradaRepository.InserirEntrada(model);
        }

        public async Task<SaidaDTO> VerificarDadosSaida(string cpf)
        {
            return await _entradaRepository.VerificarDadosSaida(cpf);
        }

    }
}
