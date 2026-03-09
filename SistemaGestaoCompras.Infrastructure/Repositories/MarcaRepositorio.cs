using Microsoft.EntityFrameworkCore;
using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Infrastructure.Data;

namespace SistemaGestaoCompras.Infrastructure.Repositories
{
    public class MarcaRepositorio : RepositorioBase<Marca>, IMarcaRepositorio
    {
        public MarcaRepositorio(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Marca>> ListarAtivosAsync()
        {
            return await _context.Marcas.Where(m => m.Ativo).ToListAsync();
        }

        public async Task<IEnumerable<Marca>> BuscarPorNomeAsync(string nome)
        {
            return await _context.Marcas.Where(m => m.Nome.Contains(nome)).ToListAsync();
        }
    }
}
