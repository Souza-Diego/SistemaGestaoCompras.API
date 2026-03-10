using SistemaGestaoCompras.Domain.Entities;
namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {        
        Task<Usuario?> BuscarPorEmailAsync(string email);        
    }
}
