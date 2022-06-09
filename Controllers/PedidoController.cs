using ForParty.Models;
using ForParty.Service;
using Microsoft.AspNetCore.Mvc;

namespace ForParty.Controllers
{
    public class PedidoController : Controller
    {
        private IPedidoService _pedidoService;
        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<IActionResult> Pedido()
        {
            var resultado = await _pedidoService.Pedido();
            return View(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> ObterProdutosEstoquePedido()
        {
            var resultado = await _pedidoService.ObterProdutosEstoquePedido();
            return View("AdicionarPedido", resultado);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarPedido(string cpf, string nome, string pedido)
        {
            try
            {
                var resultado = await _pedidoService.AdicionarPedido(cpf, nome, pedido);
                return RedirectToAction("Pedido");
            }
            catch
            {
                return RedirectToAction("ObterProdutosEstoquePedido");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ConcluirPedido(int id)
        {
            try
            {
                var resultado = await _pedidoService.ConcluirPedido(id);
                return RedirectToAction("Pedido");
            }
            catch
            {
                return RedirectToAction("Pedido");
            }
        }
    }
}
