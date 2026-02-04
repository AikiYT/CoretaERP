using Microsoft.AspNetCore.Mvc;

namespace CoretaERP.Controllers
{
    public class GestionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
