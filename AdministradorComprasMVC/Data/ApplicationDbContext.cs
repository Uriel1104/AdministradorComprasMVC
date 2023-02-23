using AdministradorComprasMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdministradorComprasMVC.Data
{
    public class ApplicationDbContext : DbContext ///IdentityDbContext*
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<DireccionProveedor> DireccionProveedores { get; set; }

        public DbSet<AspNetRoles> AspNetRoles { get; set; } 
        public DbSet<AspnetUsers> AspNetUsers { get; set; }

        public DbSet<AspNetRolesUsers> AspNetRolesUsers { get; set; }

    }
}