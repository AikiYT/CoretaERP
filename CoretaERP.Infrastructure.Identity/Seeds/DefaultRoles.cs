using CoretaERP.Application.Enums;
using CoretaERP.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoretaERP.Infrastructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> UserManager, RoleManager<IdentityRole> roleManager)
        {
            Console.WriteLine("➡️ Creando roles por defecto...");

            await roleManager.CreateAsync(new IdentityRole(Roles.superAdmin.ToString()));  // Aplica para Gerencia
            await roleManager.CreateAsync(new IdentityRole(Roles.Admi.ToString()));        // Aplica para supervisodres
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));       // Aplica para usuarios normales

            Console.WriteLine("✅ Roles creados exitosamente.");

        }
    }
}
