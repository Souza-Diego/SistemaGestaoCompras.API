using Microsoft.EntityFrameworkCore;
using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Enums;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Infrastructure.Data;

namespace SistemaGestaoCompras.Infrastructure.Repositories
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(AppDbContext context) : base(context)
        {            
        }

        public async Task<Usuario?> BuscarPorEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email.Endereco == email);
        }

        public async Task<int> ContarAdminsAsync()
        {
            return await _context.Usuarios
                .CountAsync(u => u.TipoUsuario == TipoUsuario.Administrador && u.Ativo);
        }

        public async Task<bool> ExisteAlgumAdminAsync()
        {
            return await _context.Usuarios
                .AnyAsync(u => u.TipoUsuario == TipoUsuario.Administrador && u.Ativo);
        }

        public async Task<bool> ExistePorEmailAsync(string email, Guid? ignorarUsuarioId = null)
        {
            var query = _context.Usuarios.AsQueryable();
                      
            query = query.Where(u => u.Email.Endereco == email);

            if (ignorarUsuarioId.HasValue)
            {
                query = query.Where(u => u.Id != ignorarUsuarioId.Value);
            }

            return await query.AnyAsync();
        }
    }
}
