using System;
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
            catch
            {
                return View("Entrada");
            }
        }

        [HttpGet]
        public IActionResult Saida()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> VerificarDadosSaida(string cpf)
        {
            try
            {
                var resultado = await _entradaService.VerificarDadosSaida(cpf);
                if (resultado == null)
                    return View("Saida");
                else
                    return View("Saida", resultado);
            }
            catch (Exception e)
            {
                return View("Saida");
            }
        }

        [HttpPost]
        public async Task<IActionResult> InserirSaidaCliente(string cpf)
        {
            try
            {
                var resultado = await _entradaService.InserirSaidaCliente(cpf);
                if (resultado == false)
                    return View("Saida");
                else
                    return View("Saida");
            }
            catch (Exception e)
            {
                return View("Saida");
            }
        }
    }
}
