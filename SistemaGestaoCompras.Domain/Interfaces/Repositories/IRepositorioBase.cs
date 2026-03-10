
namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IRepositorioBase<T>
    {
        Task<T?> BuscarPorIdAsync(Guid id);
        Task<IEnumerable<T>> BuscarTodosAsync();
        Task AdicionarAsync(T entidade);
        Task AtualizarAsync(T entidade);
        Task RemoverAsync(Guid id);
    }
}
