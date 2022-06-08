using ForParty.Repository;

namespace ForParty.Service
{
    public class LoginService : ILoginService
    {

        private ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<bool> InserirCadastro(string nome, string cpf, string email, string senha)
        {
            return await _loginRepository.InserirCadastro(nome, cpf, email, senha);
        }
        public async Task<bool> VerificarLogin(string email, string senha)
        {
            return await _loginRepository.VerificarLogin(email, senha);
        }
    }
}


