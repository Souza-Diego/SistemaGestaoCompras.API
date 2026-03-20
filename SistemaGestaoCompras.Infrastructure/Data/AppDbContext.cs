using Microsoft.EntityFrameworkCore;
using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.ValueObjects;

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
        public DbSet<ListaDeCompra> ListasDeCompra { get; set; } = null!;
        public DbSet<ListaDeCompraPadrao> ListasDeCompraPadrao { get; set; } = null!;
        public DbSet<Marca> Marcas { get; set; } = null!;
        public DbSet<Mercado> Mercados { get; set; } = null!;
        public DbSet<Orcamento> Orcamentos { get; set; } = null!;
        public DbSet<Produto> Produtos {  get; set; } = null!;
        public DbSet<RegistroDePreco> RegistrosDePreco { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.OwnsOne(u => u.Email, email =>
                {
                    email.Property(e => e.Endereco)
                         .HasColumnName("Email")
                         .IsRequired();
                });

                entity.OwnsOne(u => u.Senha, senha =>
                {
                    senha.Property(s => s.Hash)
                         .HasColumnName("Senha")
                         .IsRequired();
                });
            });

            modelBuilder.Entity<Compra>()
                .OwnsOne(c => c.ValorTotal, dinheiro =>
            {
                dinheiro.Property(d => d.Valor)
                .HasColumnName("ValorTotal");
            });

            modelBuilder.Entity<ItemCompra>()
                .OwnsOne(i => i.PrecoUnitario, dinheiro =>
            {
                dinheiro.Property(d => d.Valor)
                .HasColumnName("PrecoUnitario");
            });

            modelBuilder.Entity<RegistroDePreco>()
                .OwnsOne(r => r.Preco, dinheiro =>
            {
                dinheiro.Property(d => d.Valor)
                .HasColumnName("Preco");
            });

            modelBuilder.Entity<Orcamento>()
                .OwnsOne(o => o.ValorPlanejado, dinheiro =>
            {
                dinheiro.Property(d => d.Valor)
                .HasColumnName("ValorPlanejado");
            });

            modelBuilder.Entity<Produto>()
                .OwnsOne(p => p.UnidadeBase, unidade =>
            {
                unidade.Property(u => u.Nome);
                unidade.Property(u => u.Simbolo);
                unidade.Property(u => u.Tipo);
                unidade.Property(u => u.FatorBase);
            });

            modelBuilder.Entity<Produto>()
                .Property(p => p.QuantidadeBase)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<ItemLista>()
                .OwnsOne(i => i.Unidade, unidade =>
            {
                unidade.Property(u => u.Nome);
                unidade.Property(u => u.Simbolo);
                unidade.Property(u => u.Tipo);
                unidade.Property(u => u.FatorBase);
            });

            modelBuilder.Entity<ItemListaPadrao>()
                .OwnsOne(i => i.Unidade, unidade =>
            {
                unidade.Property(u => u.Nome);
                unidade.Property(u => u.Simbolo);
                unidade.Property(u => u.Tipo);
                unidade.Property(u => u.FatorBase);
            });

            modelBuilder.Entity<ItemCompra>()
                .OwnsOne(i => i.Unidade, unidade =>
            {
                unidade.Property(u => u.Nome);
                unidade.Property(u => u.Simbolo);
                unidade.Property(u => u.Tipo);
                unidade.Property(u => u.FatorBase);
            });

            modelBuilder.Entity<RegistroDePreco>()
                .OwnsOne(r => r.UnidadeReferencia, unidade =>
            {
                unidade.Property(u => u.Nome);
                unidade.Property(u => u.Simbolo);
                unidade.Property(u => u.Tipo);
                unidade.Property(u => u.FatorBase);
            });

            foreach (var property in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal)))
            {
                property.SetPrecision(18);
                property.SetScale(4);
            }

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

            modelBuilder.Entity<ItemLista>()
                .HasOne<Produto>()
                .WithMany()
                .HasForeignKey(i => i.IdProduto)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
