using Microsoft.AspNetCore.Mvc;

namespace ForParty.Controllers
{
    public class AdministracaoController : Controller
    {
        public IActionResult Analise()
        {
            return View();
        }

        public IActionResult Estoque()
        {
            return View();
        }
    }
}
