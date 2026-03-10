using Microsoft.EntityFrameworkCore;
using SistemaGestaoCompras.Domain.Entities;

namespace SistemaGestaoCompras.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        //public DbSet<Compra> Compras { get; set; }
        public DbSet<ConviteGrupo> ConvitesGrupo { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        //public DbSet<GrupoUsuario> GrupoUsuarios { get; set; }
        //public DbSet<ItemCompra> ItemCompras { get; set; }
        //public DbSet<ItemLista> ItemListas { get; set; }
        //public DbSet<ItemListaPadrao> ItemListaPadroes { get; set; }
        public DbSet<ListaDeCompra> ListaDeCompras { get; set; }
        //public DbSet<ListaDeCompraPadrao> ListaDeComprasPadroes { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Mercado> Mercados { get; set; }
        //public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<Produto> Produtos {  get; set; }
        //public DbSet<RegistroDePreco> RegistroDePrecos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


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
