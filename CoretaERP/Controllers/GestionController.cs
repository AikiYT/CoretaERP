using CoretaERP.Application.Interfaces.Services;
using CoretaERP.Application.ViewModels.Gestion;
using Microsoft.AspNetCore.Mvc;

namespace CoretaERP.Controllers
{
    public class GestionController : Controller
    {
        private readonly IGestionService _gestionService;

        public GestionController(IGestionService gestionService)
        {
            _gestionService = gestionService;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Usuarios");
        }

        public async Task<IActionResult> Usuarios()
        {
            ViewBag.Roles = await _gestionService.GetRolesAsync();
            return View(new CreateUserViewModel());
        }

        public async Task<IActionResult> Roles()
        {
            var roles = await _gestionService.GetRolesAsync();
            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel vm)
        {
            await _gestionService.CreateUserAsync(vm);
            return RedirectToAction("Usuarios");
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string nombre)
        {
            await _gestionService.CreateRoleAsync(nombre);
            return RedirectToAction("Roles");
        }

        public async Task<IActionResult> DeleteRole(string id)
        {
            await _gestionService.DeleteRoleAsync(id);
            return RedirectToAction("Roles");
        }
    }
}