using Microsoft.EntityFrameworkCore;
using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Infrastructure.Data;

namespace SistemaGestaoCompras.Infrastructure.Repositories
{
    public class GrupoRepositorio : RepositorioBase<Grupo>, IGrupoRepositorio
    {
        public GrupoRepositorio(AppDbContext context) : base(context)
        {            
        }

        public override async Task<Grupo?> ObterPorIdAsync(Guid id)
        {
            return await _context.Grupos
                .Include(g => g.Membros)
                .FirstOrDefaultAsync(g => g.Id == id);
        }        

        public async Task<IEnumerable<Grupo>> ObterPorUsuarioAsync(Guid idUsuario)
        {
            return await _context.Grupos
                .Include(g => g.Membros)
                .Where(g => g.Membros.Any(m => m.IdUsuario == idUsuario))
                .ToListAsync();
        }
    }
}
