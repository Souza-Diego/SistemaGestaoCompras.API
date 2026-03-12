using Microsoft.EntityFrameworkCore;
using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Infrastructure.Data;

namespace SistemaGestaoCompras.Infrastructure.Repositories
{
    public class OrcamentoRepositorio : RepositorioBase<Orcamento>, IOrcamentoRepositorio
    {
        public OrcamentoRepositorio(AppDbContext context) : base(context)
        {
        }

        public async Task<Orcamento?> ObterPorUsuarioMesAsync(Guid idUsuario, int ano, int mes)
        {
            return await _context.Set<Orcamento>()
                .FirstOrDefaultAsync(o =>
                    o.IdUsuario == idUsuario &&
                    o.Ano == ano &&
                    o.Mes == mes);
        }

        public async Task<IEnumerable<Orcamento>> ObterPorUsuarioAsync(Guid usuarioId)
        {
            return await _context.Set<Orcamento>()
                .Where(o => o.IdUsuario == usuarioId)
                .ToListAsync();
        }
    }
}