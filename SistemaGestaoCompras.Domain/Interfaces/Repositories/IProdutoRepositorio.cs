using SistemaGestaoCompras.Domain.Entities;
namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IProdutoRepositorio
    {
        Task<Produto?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Produto>> ObterPorCategoriaAsync(Guid categoria);
        Task<IEnumerable<Produto>> BuscarPorNomeAsync(string nome);
        Task AdicionarAsync(Produto produto);
        Task AtualizarAsync(Produto produto);       
    }
}
