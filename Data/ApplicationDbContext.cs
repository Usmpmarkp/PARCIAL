using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PARCIAL.Models;

namespace PARCIAL.Data
{
    public class ApplicationDbContext : IdentityDbContext // Usa IdentityDbContext si estás manejando usuarios y roles
    // Si no necesitas Identity, usa DbContext en lugar de IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Remesas> Remesas { get; set; }

        // Otras configuraciones
    }
}
