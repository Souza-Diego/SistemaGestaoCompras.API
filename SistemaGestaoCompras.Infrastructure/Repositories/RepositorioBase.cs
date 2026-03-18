using Microsoft.EntityFrameworkCore;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Infrastructure.Data;

namespace SistemaGestaoCompras.Infrastructure.Repositories
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        protected readonly AppDbContext _context;

        public RepositorioBase(AppDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T?> BuscarPorIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> BuscarTodosAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task AdicionarAsync(T entidade)
        {
            await _context.Set<T>().AddAsync(entidade);
            await _context.SaveChangesAsync();
        }

        public virtual async Task AtualizarAsync(T entidade)
        {
            //_context.Set<T>().Update(entidade);
            await _context.SaveChangesAsync();
        }

        public virtual async Task RemoverAsync(Guid id)
        {
            var entidade = await BuscarPorIdAsync(id);
            if (entidade != null)
            {
                _context.Set<T>().Remove(entidade);
                await _context.SaveChangesAsync();
            }
        }
    }
}
