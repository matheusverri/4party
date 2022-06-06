namespace ForParty.Repository
{
    public interface ILoginRepository
    {
        Task<bool> InserirCadastro(string nome, string cpf, string email, string senha);
        Task<bool> VerificarLogin(string email, string senha);
        
    }
}
