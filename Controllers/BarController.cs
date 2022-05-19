using Microsoft.AspNetCore.Mvc;

namespace ForParty.Controllers
{
    public class BarController : Controller
    {
        public IActionResult Pedido()
        {
            return View();
        }
    }
}
