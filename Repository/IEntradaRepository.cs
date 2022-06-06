using ForParty.Models;

namespace ForParty.Repository
{
    public interface IEntradaRepository
    {
        Task<bool> InserirEntrada(EntradaDTO model);
        Task<SaidaDTO> VerificarDadosSaida(string cpf);
        Task<bool> InserirSaidaCliente(string cpf);
    }
}