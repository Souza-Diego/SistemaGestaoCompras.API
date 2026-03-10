using Microsoft.EntityFrameworkCore;
using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Infrastructure.Data;

namespace SistemaGestaoCompras.Infrastructure.Repositories
{
    public class ListaDeComprasRepositorio
        : RepositorioBase<ListaDeCompra>, IListaDeComprasRepositorio
    {
        public ListaDeComprasRepositorio(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ListaDeCompra>> ListarPorUsuarioIdAsync(Guid idUsuario)
        {
            return await _context.Set<ListaDeCompra>()
                .Where(l => l.IdUsuario == idUsuario)
                .ToListAsync();
        }

        public async Task<IEnumerable<ListaDeCompra>> ListarPorGrupoIdAsync(Guid idGrupo)
        {
            return await _context.Set<ListaDeCompra>()
                .Where(l => l.IdGrupo == idGrupo)
                .ToListAsync();
        }
    }
}
