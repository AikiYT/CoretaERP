using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoretaERP.Application.ViewModels.Gestion
{
    public class UsuariosViewModel
    {
        public CreateUserViewModel NuevoUsuario { get; set; }
        public List<UserViewModel> Usuarios { get; set; }
    }
}
