using Microsoft.EntityFrameworkCore;
using Sistema_de_Identificacao.Models;

namespace Sistema_de_Identificacao.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Logradouro> Logradouros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasIndex(c => c.Email).IsUnique();
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Logradouros)
                .WithOne()
                .HasForeignKey(l => l.ClienteId);
        } 
    }
}
