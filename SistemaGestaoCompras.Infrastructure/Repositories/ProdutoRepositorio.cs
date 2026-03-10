using Microsoft.EntityFrameworkCore;
using SistemaGestaoCompras.Domain.Entities;
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
            return await _context.Produtos.Where(p => p.IdCategoria == idCategoria).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ListarAtivosAsync()
        {
            return await _context.Produtos.Where(p => p.Ativo).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> BuscarPorNomeAsync(string nome)
        {
            return await _context.Produtos
                .Where(p => EF.Functions.Like(p.Nome, $"%{nome}%"))
                .ToListAsync();
        }
    }
}
