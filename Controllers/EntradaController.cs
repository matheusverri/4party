using Microsoft.AspNetCore.Mvc;

namespace ForParty.Controllers
{
    public class EntradaController : Controller
    {
        #region tela

        [HttpGet]
        public IActionResult Entrada()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Saida()
        {
            return View();
        }

        #endregion
    }
}
