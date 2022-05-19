using Microsoft.AspNetCore.Mvc;

namespace ForParty.Controllers
{
    public class BarRepository : Controller
    {
        public IActionResult Pedido()
        {
            return View();
        }
    }
}
