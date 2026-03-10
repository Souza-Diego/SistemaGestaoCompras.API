using Microsoft.EntityFrameworkCore;
using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Infrastructure.Data;


namespace SistemaGestaoCompras.Infrastructure.Repositories
{
    public class CategoriaRepositorio : RepositorioBase<Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Categoria>> ListarAtivosAsync()
        {
            return await _context.Categorias.Where(c => c.Ativo).ToListAsync();
        }

        public async Task<IEnumerable<Categoria>> BuscarPorNomeAsync(string nome)
        {
            return await _context.Categorias
                .Where(c => c.Nome.Contains(nome))
                .ToListAsync();
        }
    }    
}
