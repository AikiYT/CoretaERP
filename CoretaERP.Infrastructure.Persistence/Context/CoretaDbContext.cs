using CoretaERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CoretaERP.Infrastructure.Persistence.Context
{
    public class CoretaDbContext : DbContext
    {
        public CoretaDbContext(DbContextOptions<CoretaDbContext> options)
            : base(options)
        {
        }

       
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<GestionConfig> GestionConfigs { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<MovimientoCaja> MovimientosCaja { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<ReporteGeneral> ReportesGenerales { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relaciones básicas ejemplo
            modelBuilder.Entity<Producto>()
                .HasOne<Proveedor>()
                .WithMany()
                .HasForeignKey("ProveedorId");

            modelBuilder.Entity<Venta>()
                .HasOne<Cliente>()
                .WithMany()
                .HasForeignKey("ClienteId");

            modelBuilder.Entity<Compra>()
                .HasOne<Proveedor>()
                .WithMany()
                .HasForeignKey("ProveedorId");
        }
    }
}