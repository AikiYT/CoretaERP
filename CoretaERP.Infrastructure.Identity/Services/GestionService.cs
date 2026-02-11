using CoretaERP.Application.DTOs.Account;
using CoretaERP.Application.Interfaces.Services;
using CoretaERP.Application.ViewModels.Gestion;
using CoretaERP.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoretaERP.Infrastructure.Identity.Services
{
    public class GestionService : IGestionService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public GestionService(
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // 🔹 OBTENER ROLES
        public async Task<List<RoleViewModel>> GetRolesAsync()
        {
            return await _roleManager.Roles
                .Select(r => new RoleViewModel
                {
                    Id = r.Id,
                    Nombre = r.Name
                })
                .ToListAsync();
        }

        // 🔹 CREAR ROL
        public async Task CreateRoleAsync(string nombre)
        {
            if (!await _roleManager.RoleExistsAsync(nombre))
            {
                await _roleManager.CreateAsync(new IdentityRole(nombre));
            }
        }

        // 🔹 ELIMINAR ROL
        public async Task DeleteRoleAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
            }
        }

        // 🔹 CREAR USUARIO
        public async Task CreateUserAsync(CreateUserViewModel vm)
        {
            var user = new ApplicationUser
            {
                UserName = vm.Email,
                Email = vm.Email,
                FirstName = vm.Nombre,
                LastName = "N/A" // para evitar NULL
            };
            var result = await _userManager.CreateAsync(user, vm.Password);

            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

            await _userManager.AddToRoleAsync(user, vm.Rol);
        }
        public async Task<List<UserViewModel>> GetUsersAsync()
        {
            var users = _userManager.Users.ToList();

            var list = new List<UserViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                list.Add(new UserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Rol = roles.FirstOrDefault()
                });
            }

            return list;
        }
    }
}