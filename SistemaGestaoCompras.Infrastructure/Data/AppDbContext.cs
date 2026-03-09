using Microsoft.EntityFrameworkCore;
using SistemaGestaoCompras.Domain.Entities;

namespace SistemaGestaoCompras.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<GrupoUsuario> GrupoUsuarios { get; set; }
        public DbSet<ConviteGrupo> ConvitesGrupo { get; set; }
        public DbSet<Produto> Produtos {  get; set; }
        public DbSet<Mercado> Mercados { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Grupo>()
                .HasMany(g => g.Membros)
                .WithOne()
                .HasForeignKey(m => m.IdGrupo);

            modelBuilder.Entity<GrupoUsuario>().HasKey(x => x.Id);
            modelBuilder.Entity<ConviteGrupo>().HasKey(x => x.Id);

        }
    }
}
