using CoretaERP.Application.ViewModels.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoretaERP.Application.Interfaces.Services
{
    public interface IGestionService
    {
        Task CreateUserAsync(CreateUserViewModel vm);
        Task<List<RoleViewModel>> GetRolesAsync();
        Task CreateRoleAsync(string roleName);
        Task DeleteRoleAsync(string roleId);
        Task<List<UserViewModel>> GetUsersAsync();
    }
}
