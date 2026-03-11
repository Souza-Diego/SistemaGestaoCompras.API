using Microsoft.EntityFrameworkCore;
using SistemaGestaoCompras.Domain.Entities;

namespace SistemaGestaoCompras.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; } = null!;
        //public DbSet<Compra> Compras { get; set; } = null!;
        public DbSet<ConviteGrupo> ConvitesGrupo { get; set; } = null!;
        public DbSet<Grupo> Grupos { get; set; } = null!;
        //public DbSet<GrupoUsuario> GrupoUsuarios { get; set; } = null!;
        //public DbSet<ItemCompra> ItemCompras { get; set; } = null!;
        //public DbSet<ItemLista> ItemListas { get; set; } = null!;
        //public DbSet<ItemListaPadrao> ItemListaPadroes { get; set; } = null!;
        public DbSet<ListaDeCompra> ListaDeCompras { get; set; } = null!;
        public DbSet<ListaDeCompraPadrao> ListasPadrao { get; set; } = null!;
        public DbSet<Marca> Marcas { get; set; } = null!;
        public DbSet<Mercado> Mercados { get; set; } = null!;
        //public DbSet<Orcamento> Orcamentos { get; set; } = null!;
        public DbSet<Produto> Produtos {  get; set; } = null!;
        //public DbSet<RegistroDePreco> RegistroDePrecos { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } = null!;


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
