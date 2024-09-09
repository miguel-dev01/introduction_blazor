using blazor_test.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace blazor_test.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Usuario> usuario { get; set; }
        public DbSet<Movimiento> Movimiento { get; set; }
    }
}