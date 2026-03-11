using Microsoft.EntityFrameworkCore;
using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Infrastructure.Data;

namespace SistemaGestaoCompras.Infrastructure.Repositories
{
    public class CompraRepositorio
        : RepositorioBase<Compra>, ICompraRepositorio
    {
        public CompraRepositorio(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Compra>> ObterPorUsuarioAsync(Guid usuarioId)
        {
            return await _context.Set<Compra>()
                .Include(c => c.Itens)
                .Where(c => c.IdUsuario == usuarioId)
                .OrderByDescending(c => c.DataCompra)
                .ToListAsync();
        }

        public async Task<IEnumerable<Compra>> ObterPorPeriodoAsync(Guid idUsuario, DateTime inicio, DateTime fim)
        {
            return await _context.Set<Compra>()
                .Include(c => c.Itens)
                .Where(c => c.IdUsuario == idUsuario &&
                            c.DataCompra >= inicio &&
                            c.DataCompra <= fim)
                .OrderByDescending(c => c.DataCompra)
                .ToListAsync();
        }
    }
}