using SistemaGestaoCompras.Domain.Entities;
namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario?> ObterPorIdAsync(Guid id);
        Task<Usuario?> ObterPorEmailAsync(string email);
        Task<IEnumerable<Usuario>> ObterTodosAsync();
        Task AdicionarAsync(Usuario usuario);
        Task AtualizarAsync(Usuario usuario);
        Task RemoverAsync(Guid id);
    }
}
