using ForParty.Models;
using ForParty.Service;
using Microsoft.AspNetCore.Mvc;

namespace ForParty.Controllers
{
    public class EstoqueController : Controller
    {
        private IEstoqueService _estoqueService;
        public EstoqueController(IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        [HttpGet]
        public async Task<IActionResult> Estoque()
        {
            var resultado = await _estoqueService.Estoque();
            if (resultado == null)
                return View();
            else
                return View(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirEstoque(int id)
        {
            var resultado = await _estoqueService.ExcluirEstoque(id);
            if (resultado == false)
                return View();
            else
                return RedirectToAction("Estoque", "Estoque");
        }

        [HttpGet]
        public async Task<IActionResult> ObterEditarEstoque(int id)
        {
            var resultado = await _estoqueService.ObterEditarEstoque(id);
            if (resultado == null)
                return View();
            else
                return View("EditarEstoque", resultado);
        }

        [HttpPost]
        public async Task<IActionResult> EditarEstoque(EditaEstoqueDTO model)
        {
            var resultado = await _estoqueService.EditarEstoque(model);
            if (resultado == false)
                return View("EditarEstoque");
            else
                return RedirectToAction("Estoque", "Estoque");
        }

        [HttpGet]
        public async Task<IActionResult> ObterAdicionarEstoque(int id)
        {
            var resultado = await _estoqueService.ObterAdicionarEstoque(id);
            if (resultado == null)
                return View();
            else
                return View("AdicionarEstoque", resultado);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarEstoque(AdicionarEstoqueDTO model)
        {
            var resultado = await _estoqueService.AdicionarEstoque(model);
            if (resultado == false)
                return View("AdicionarEstoque");
            else
                return RedirectToAction("Estoque", "Estoque");
        }

        [HttpGet]
        public IActionResult AdicionarItemEstoque()
        {
            return View("AdicionarItemEstoque");
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarItemEstoque(AdicionarItemEstoqueDTO model)
        {
            var resultado = await _estoqueService.AdicionarItemEstoque(model);
            if (resultado == false)
                return View("AdicionarItemEstoque");
            else
                return RedirectToAction("Estoque", "Estoque");
        }
    }
}
