using Microsoft.EntityFrameworkCore;
using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Infrastructure.Data;

namespace SistemaGestaoCompras.Infrastructure.Repositories
{
    public class ListaDeComprasPadraoRepositorio
        : RepositorioBase<ListaDeCompraPadrao>, IListaDeComprasPadraoRepositorio
    {
        public ListaDeComprasPadraoRepositorio(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ListaDeCompraPadrao>> ObterPorUsuarioAsync(Guid usuarioId)
        {
            return await _context.Set<ListaDeCompraPadrao>()
                .Where(l => l.IdUsuario == usuarioId && l.Ativo)
                .ToListAsync();
        }
    }
}