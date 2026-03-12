using Microsoft.EntityFrameworkCore;
using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Infrastructure.Data;

namespace SistemaGestaoCompras.Infrastructure.Repositories
{
    public class RegistroDePrecoRepositorio
        : RepositorioBase<RegistroDePreco>, IRegistroDePrecoRepositorio
    {
        public RegistroDePrecoRepositorio(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<RegistroDePreco>> ObterPorProdutoAsync(Guid produtoId)
        {
            return await _context.Set<RegistroDePreco>()
                .Where(r => r.IdProduto == produtoId)
                .OrderByDescending(r => r.DataRegistro)
                .ToListAsync();
        }

        public async Task<IEnumerable<RegistroDePreco>> ObterPorUsuarioAsync(Guid usuarioId)
        {
            return await _context.Set<RegistroDePreco>()
                .Where(r => r.IdUsuario == usuarioId)
                .OrderByDescending(r => r.DataRegistro)
                .ToListAsync();
        }
    }
}
