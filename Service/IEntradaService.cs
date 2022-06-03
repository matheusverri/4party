using ForParty.Models;

namespace ForParty.Service
{
    public interface IEntradaService
    {
        Task<bool> InserirEntrada(EntradaDTO model);
        Task<SaidaDTO> VerificarDadosSaida(string cpf);
    }
}