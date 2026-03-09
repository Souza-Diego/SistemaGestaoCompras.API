using SistemaGestaoCompras.Domain.Entities;
namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IProdutoRepositorio : IRepositorioBase<Produto>
    {        
        Task<IEnumerable<Produto>> ObterPorCategoriaAsync(Guid categoria);
        Task<IEnumerable<Produto>> BuscarPorNomeAsync(string nome);
        Task<IEnumerable<Produto>> ListarAtivosAsync();
    }
}
