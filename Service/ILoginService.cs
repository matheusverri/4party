namespace ForParty.Service
{
    public interface ILoginService
    {

        Task<bool> InserirCadastro(string nome, string cpf, string email, string senha);
        Task<bool> VerificarLogin(string email, string senha);
    }
}
