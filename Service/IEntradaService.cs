using ForParty.Models;

namespace ForParty.Service
{
    public interface IEntradaService
    {
        Task<bool> InserirEntrada(EntradaDTO model);
        Task<string> VerificarDadosSaida(SaidaDTO model);
    }
}