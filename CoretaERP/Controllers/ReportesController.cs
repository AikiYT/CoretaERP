using Microsoft.AspNetCore.Mvc;

namespace CoretaERP.Controllers
{
    public class ReportesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
