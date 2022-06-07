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
        public async Task<IActionResult> AdicionarEstoque(int id)
        {
            var resultado = await _estoqueService.AdicionarEstoque(id);
            if (resultado == null)
                return View();
            else
                return View("FormularioEstoque", resultado);
        }

        [HttpGet]
        public async Task<IActionResult> EditarEstoque(int id)
        {
            var resultado = await _estoqueService.EditarEstoque(id);
            if (resultado == null)
                return View();
            else
                return View("FormularioEstoque", resultado);
        }
    }
}
