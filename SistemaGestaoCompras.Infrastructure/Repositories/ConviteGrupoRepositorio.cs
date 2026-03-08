using Microsoft.EntityFrameworkCore;
using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Infrastructure.Data;

namespace SistemaGestaoCompras.Infrastructure.Repositories
{
    public class ConviteGrupoRepositorio : RepositorioBase<ConviteGrupo>, IConviteGrupoRepositorio
    {
        public ConviteGrupoRepositorio(AppDbContext context) : base(context)
        {            
        }

        public async Task<ConviteGrupo?> ObterPorCodigoAsync(string codigo)
        {
            return await _context.ConvitesGrupo
                .FirstOrDefaultAsync(c => c.Codigo == codigo);
        }
    }
    
}
