using ForParty.Models;

namespace ForParty.Repository
{
    public interface ICaixaRepository
    {
        Task<ClienteCaixaDTO> VerificarConsumoCaixa(string cpf);
        Task<bool> ConcluirPagamento(string cpf);
    }
}