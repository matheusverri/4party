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
        public async Task<IActionResult> InserirEntrada(EntradaDTO model)
        {
            try
            {
                var resultado = await _entradaService.InserirEntrada(model);
                return View("Entrada");
            }
            catch(Exception e)
            {
                return View("Entrada");
            }
        }

        [HttpGet]
        public IActionResult Saida()
        {
            var model = new SaidaDTO
            {
                Id = null,
                CPF = "",
                Nome = "",
                Status = null
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> VerificarDadosSaida(string cpf)
        {
            try
            {
                var resultado = await _entradaService.VerificarDadosSaida(cpf);
                return View("Saida", resultado);
            }
            catch
            {
                return View("Saida");
            }
        }
    }
}
