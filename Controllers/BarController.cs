using Microsoft.AspNetCore.Mvc;

namespace ForParty.Controllers
{
    public class BarController : Controller
    {
        [HttpGet]
        public IActionResult Pedido()
        {
            return View();
        }
    }
}
