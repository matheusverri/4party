using ForParty.Models;

namespace ForParty.Repository
{
    public interface IAdministracaoRepository
    {
        Task<List<AdministracaoDTO>> VerificarDadosAnalise();
    }
}