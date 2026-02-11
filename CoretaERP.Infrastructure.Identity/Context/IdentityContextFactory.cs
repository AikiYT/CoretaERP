using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoretaERP.Infrastructure.Identity.Context
{
    public class IdentityContextFactory : IDesignTimeDbContextFactory<IdentityContext>
    {


        // ESTE ES EL QUE FUNCIONA CORRECTAMENTE: AQUI SE COLOCA EL CONEXION STRING DE LA DB
        public IdentityContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>();
            //optionsBuilder.UseSqlServer("Server=DESKTOP-UH1LS5T\\SQLEXPRESS;Database=SGBL;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;Encrypt=False");
            optionsBuilder.UseSqlServer("Server=localhost;Database=CoretaERP;User Id=sa;Password=abm23;TrustServerCertificate=True;Encrypt=False;MultipleActiveResultSets=True");


            return new IdentityContext(optionsBuilder.Options);
        }


    }

}

