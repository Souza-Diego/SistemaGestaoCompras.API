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
        public DbSet<Compra> Compras { get; set; } = null!;
        public DbSet<ConviteGrupo> ConvitesGrupo { get; set; } = null!;
        public DbSet<Grupo> Grupos { get; set; } = null!;
        public DbSet<GrupoUsuario> GrupoUsuarios { get; set; } = null!;
        public DbSet<ItemCompra> ItensCompra { get; set; } = null!;
        public DbSet<ItemLista> ItensListas { get; set; } = null!;
        public DbSet<ItemListaPadrao> ItensListaPadrao { get; set; } = null!;
        public DbSet<ListaDeCompra> ListaDeCompras { get; set; } = null!;
        public DbSet<ListaDeCompraPadrao> ListasPadrao { get; set; } = null!;
        public DbSet<Marca> Marcas { get; set; } = null!;
        public DbSet<Mercado> Mercados { get; set; } = null!;
        public DbSet<Orcamento> Orcamentos { get; set; } = null!;
        public DbSet<Produto> Produtos {  get; set; } = null!;
        public DbSet<RegistroDePreco> RegistroDePrecos { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Grupo>()
                .HasMany(g => g.Membros)
                .WithOne()
                .HasForeignKey(m => m.IdGrupo);

            modelBuilder.Entity<GrupoUsuario>()
                .HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(x => x.IdUsuario);

            modelBuilder.Entity<ItemCompra>()
                .HasOne<Compra>()
                .WithMany(c => c.Itens)
                .HasForeignKey(i => i.IdCompra);

            modelBuilder.Entity<ItemLista>()
                .HasOne<ListaDeCompra>()
                .WithMany(l => l.Itens)
                .HasForeignKey(i => i.IdListaDeCompras);

            modelBuilder.Entity<ItemListaPadrao>()
                .HasOne<ListaDeCompraPadrao>()
                .WithMany(l => l.Itens)
                .HasForeignKey(i => i.IdListaDeComprasPadrao);

            modelBuilder.Entity<RegistroDePreco>()
                .HasIndex(r => new { r.IdProduto, r.IdMercado, r.DataRegistro })
                .IsUnique();

            modelBuilder.Entity<Orcamento>()
                .HasIndex(o => new { o.IdUsuario, o.Ano, o.Mes })
                .IsUnique();

            modelBuilder.Entity<GrupoUsuario>()
                .HasIndex(g => new { g.IdUsuario, g.IdGrupo })
                .IsUnique();
        }
    }
}
