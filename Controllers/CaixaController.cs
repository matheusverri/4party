using Microsoft.AspNetCore.Mvc;

namespace ForParty.Controllers
{
    public class CaixaController : Controller
    {
        public IActionResult Caixa()
        {
            return View();
        }
    }
}
