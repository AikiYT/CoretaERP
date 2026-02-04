using Microsoft.AspNetCore.Mvc;

namespace CoretaERP.Controllers
{
    public class VentasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
