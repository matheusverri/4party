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

        //[HttpPost]
        //public async Task<IActionResult> InserirPedido(PedidoDTO model)
        //{
        //    try
        //    {
        //        var resultado = await _entradaService.InserirEntrada(model);
        //        return View("Pedido");
        //    }
        //    catch
        //    {
        //        return View("Pedido");
        //    }
        //}
    }
}
