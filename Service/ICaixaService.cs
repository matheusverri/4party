using ForParty.Models;

namespace ForParty.Service
{
    public interface ICaixaService
    {
        Task<ClienteCaixaDTO> VerificarConsumoCaixa(string cpf);
        Task<bool> ConcluirPagamento(string cpf);
    }
}