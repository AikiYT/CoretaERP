using Microsoft.AspNetCore.Mvc;

namespace CoretaERP.Controllers
{
    public class InventarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
