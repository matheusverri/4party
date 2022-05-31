using ForParty.Models;

namespace ForParty.Repository
{
    public interface IEntradaRepository
    {
        Task<bool> InserirEntrada(EntradaDTO model);
        Task<string> VerificarDadosSaida(SaidaDTO model);
    }
}