using eficiencia_rural.Models;
using Microsoft.EntityFrameworkCore;

namespace eficiencia_rural.DataContexts
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Animal> Animais { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<Piquete> Piquetes { get; set; }
        public DbSet<Producao> Producoes { get; set; }
        public DbSet<Propriedade> Propriedades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}
