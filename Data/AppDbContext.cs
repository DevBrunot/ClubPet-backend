using Microsoft.EntityFrameworkCore;
using MeuProjetoAPI.Models; 

namespace ClubPetAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; } // DbSet para a entidade Usuario

        // Adicione outros DbSet conforme necessário
    }
}
