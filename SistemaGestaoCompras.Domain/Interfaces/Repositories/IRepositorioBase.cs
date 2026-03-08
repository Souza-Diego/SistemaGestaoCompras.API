
namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IRepositorioBase<T>
    {
        Task<T?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<T>> ObterTodosAsync();
        Task AdicionarAsync(T entidade);
        Task AtualizarAsync(T entidade);
        Task RemoverAsync(Guid id);
    }
}
