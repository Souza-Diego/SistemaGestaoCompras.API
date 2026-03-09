using Microsoft.EntityFrameworkCore;
using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Infrastructure.Data;

namespace SistemaGestaoCompras.Infrastructure.Repositories
{
    public class MercadoRepositorio : RepositorioBase<Mercado>, IMercadoRepositorio
    {
        public MercadoRepositorio(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Mercado>> ListarAtivosAsync()
        {
            return await _context.Mercados.Where(m => m.Ativo).ToListAsync();
        }

        public async Task<IEnumerable<Mercado>> BuscarPorNomeAsync(string nome)
        {
            return await _context.Mercados
                .Where(m => m.Nome.Contains(nome))
                .ToListAsync();
        }
    }
}
