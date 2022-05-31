using ForParty.Models;
using ForParty.Service;
using Microsoft.AspNetCore.Mvc;

namespace ForParty.Controllers
{
    public class EntradaController : Controller
    {
        private readonly IEntradaService _entradaService;
        public EntradaController(IEntradaService entradaService)
        {
            _entradaService = entradaService;
        }

        [HttpGet]
        public IActionResult Entrada()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> InserirEntrada(EntradaDTO model)
        {
            try
            {
                var resultado = await _entradaService.InserirEntrada(model);
                return Json(new { success = true, data = resultado });
            }
            catch
            {
                return Json(new { success = false});
            }
        }

        [HttpGet]
        public IActionResult Saida()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> VerificarDadosSaida(SaidaDTO model)
        {
            try
            {
                var resultado = await _entradaService.VerificarDadosSaida(model);
                return Json(new { success = true, data = resultado });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
    }
}
