using ForParty.Models;
using ForParty.Service;
using Microsoft.AspNetCore.Mvc;

namespace ForParty.Controllers
{
    public class AdministracaoController : Controller
    {
        private readonly IAdministracaoService _administracaoService;
        public AdministracaoController(IAdministracaoService administracaoService)
        {
            _administracaoService = administracaoService;
        }

        [HttpGet]
        public async Task<IActionResult> Analise()
        {
            try
            {
                var resultado = await _administracaoService.VerificarDadosAnalise();
                if (resultado == null)
                    return View("Analise");
                else
                    return View("Analise", resultado);
            }
            catch (Exception e)
            {
                return View("Analise");
            }
        }
    }
}
