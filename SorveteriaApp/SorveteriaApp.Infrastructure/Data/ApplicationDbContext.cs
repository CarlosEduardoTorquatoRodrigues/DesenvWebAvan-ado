using Microsoft.EntityFrameworkCore;
using SorveteriaApp.Domain.Entities;

namespace SorveteriaApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Sabor> Sabores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sabor>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CodigoProduto)
                    .IsRequired()
                    .HasMaxLength(7);

                entity.HasIndex(e => e.CodigoProduto)
                    .IsUnique();

                entity.Property(e => e.PrecoPorKg)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Disponivel)
                    .IsRequired();

                entity.Property(e => e.DataCriacao)
                    .IsRequired();
            });
        }
    }
}
