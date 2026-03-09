using SistemaGestaoCompras.Domain.Entities;

namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IMarcaRepositorio : IRepositorioBase<Marca>
    {
        public Task<IEnumerable<Marca>> ListarAtivosAsync();
        public Task<IEnumerable<Marca>> BuscarPorNomeAsync(string nome);
    }
}
