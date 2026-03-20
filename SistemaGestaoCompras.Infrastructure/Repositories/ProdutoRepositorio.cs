using Microsoft.EntityFrameworkCore;
using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Enums;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Infrastructure.Data;

namespace SistemaGestaoCompras.Infrastructure.Repositories
{
    public class ProdutoRepositorio : RepositorioBase<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Produto>> ObterPorCategoriaAsync(Guid idCategoria)
        {
            return await _context.Produtos
                .Where(p => p.Ativo && p.IdCategoria == idCategoria)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ListarAtivosAsync()
        {
            return await _context.Produtos
                .Where(p => p.Ativo)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> BuscarPorNomeAsync(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return Enumerable.Empty<Produto>();

            nome = nome.Trim();

            return await _context.Produtos
                .Where(p => p.Ativo && EF.Functions.Like(p.Nome, $"%{nome}%"))
                .ToListAsync();
        }

        public async Task<bool> ExisteProdutoDuplicadoAsync(
            string nome, 
            Guid? idMarca, 
            string simboloUnidade, 
            decimal? quantidadeBase,
            Guid? ignorarProdutoId = null)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return false;

            nome = nome.Trim().ToLowerInvariant();
            simboloUnidade = simboloUnidade.Trim().ToLowerInvariant();

            var query = _context.Produtos.AsQueryable();

            query = query.Where(p =>
                p.Ativo &&
                p.Nome.ToLower() == nome &&
                p.IdMarca == idMarca &&
                p.UnidadeBase.Simbolo.ToLower() == simboloUnidade
            );

            if (quantidadeBase.HasValue)
            {
                query = query.Where(p => p.QuantidadeBase == quantidadeBase.Value);
            }
            else
            {
                query = query.Where(p => p.QuantidadeBase == null);
            }

            if (ignorarProdutoId.HasValue)
            {
                query = query.Where(p => p.Id != ignorarProdutoId.Value);
            }

            return await query.AnyAsync();
        }

        public async Task<IEnumerable<Produto>> ListarPorUsuarioAsync(Guid usuarioId)
        {
            return await _context.Produtos
                .Where(p =>
                    p.Ativo &&
                    (p.Tipo == TipoProduto.Global ||
                     p.IdCriadoPorUsuario == usuarioId))
                .ToListAsync();
        }
    }
}