using ForParty.Models;
using ForParty.Repository;
using ForParty.Service;
using Microsoft.AspNetCore.Mvc;

namespace ForParty.Controllers
{
    public class LoginController : Controller
    {
        private ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> VerificarLogin(string email, string senha)
        {
            try
            {
                var resultado = await _loginService.VerificarLogin(email, senha);

                if (resultado)
                    return RedirectToAction("Entrada", "Entrada");
                else
                    return RedirectToAction("Login");  
            }
            catch (Exception e)
            {
                return View("Login");
            }
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(string nome, string cpf, string email, string senha)
        {
            var resultado = await _loginService.InserirCadastro(nome, cpf, email, senha);
            return RedirectToAction("Login", "Login");
        }

    }
}
