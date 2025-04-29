using Microsoft.EntityFrameworkCore;
using SoftlineApp.Models;

namespace SoftlineApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Produto>()
                    .Property(p => p.ValorVenda)
                    .HasPrecision(18, 2);

                modelBuilder.Entity<Produto>()
                    .Property(p => p.PesoBruto)
                    .HasPrecision(18, 2);

                modelBuilder.Entity<Produto>()
                    .Property(p => p.PesoLiquido)
                    .HasPrecision(18, 2);
            }
    }
}