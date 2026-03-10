using SistemaGestaoCompras.Domain.Entities;

namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepositorio : IRepositorioBase<Categoria>
    {
        Task<IEnumerable<Categoria>> ListarAtivosAsync();
        Task<IEnumerable<Categoria>> BuscarPorNomeAsync(string nome);
    }
}
