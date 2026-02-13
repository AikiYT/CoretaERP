using CoretaERP.Application.Interfaces.Services;
using CoretaERP.Application.ViewModels.Gestion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CoretaERP.Controllers
{
    [Authorize(Roles = "Administrador,SuperAdmin")]
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
            var viewModel = new UsuariosViewModel
            {
                NuevoUsuario = new CreateUserViewModel(),
                Usuarios = await _gestionService.GetUsersAsync()
            };

            ViewBag.Roles = await _gestionService.GetRolesAsync();

            return View(viewModel);
        }

        public async Task<IActionResult> Roles()
        {
            var roles = await _gestionService.GetRolesAsync();
            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UsuariosViewModel model)
        {
            await _gestionService.CreateUserAsync(model.NuevoUsuario);
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