using Microsoft.EntityFrameworkCore;
using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Infrastructure.Data;

namespace SistemaGestaoCompras.Infrastructure.Repositories
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(AppDbContext context) : base(context)
        {            
        }

        public async Task<Usuario?> ObterPorEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email.Endereco == email);
        }
    }
}
