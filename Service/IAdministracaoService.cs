using ForParty.Models;

namespace ForParty.Service
{
    public interface IAdministracaoService
    {
        Task<List<AdministracaoDTO>> VerificarDadosAnalise();
    }
}
