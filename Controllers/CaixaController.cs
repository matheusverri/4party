using ForParty.Models;
using ForParty.Service;
using Microsoft.AspNetCore.Mvc;

namespace ForParty.Controllers
{
    public class CaixaController : Controller
    {
        private ICaixaService _caixaService;
        public CaixaController(ICaixaService caixaService)
        {
            _caixaService = caixaService;
        }

        [HttpGet]
        public IActionResult Caixa()
        {
       
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> VerificarDadosCaixa(string cpf)
        {
            try
            {
                var resultado = await _caixaService.VerificarConsumoCaixa(cpf);
                return View("Caixa", resultado);
            }
            catch (Exception e)
            {
                return View("Caixa");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ConcluirPagamento(string cpf)
        {
            try
            {
                var resultado = await _caixaService.ConcluirPagamento(cpf);
                return View("Caixa");
            }
            catch (Exception e)
            {
                return View("Caixa");
            }
        }
    }
}
