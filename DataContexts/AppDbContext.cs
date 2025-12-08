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
            modelBuilder.Entity<Animal>()
              .HasOne(a => a.Categoria)
              .WithMany()
              .HasForeignKey(a => a.fk_id_categoria);

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Propriedade)
                .WithMany()
                .HasForeignKey(a => a.fk_id_propriedade);

            modelBuilder.Entity<Producao>()
                .HasOne(a => a.Animal)
                .WithMany()
                .HasForeignKey(a => a.fk_id_animal);

            // Piquete

            modelBuilder.Entity<Piquete>()
            .Property(p => p.fk_id_propriedade)
            .HasColumnName("fk_id_propriedade");

            modelBuilder.Entity<Piquete>()
                .HasOne(p => p.Propriedade)
                .WithMany()
                .HasForeignKey(p => p.fk_id_propriedade);

        }

    }
}
