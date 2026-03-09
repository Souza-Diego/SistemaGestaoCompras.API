using SistemaGestaoCompras.Domain.Entities;

namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IMercadoRepositorio : IRepositorioBase<Mercado>
    {
        Task<IEnumerable<Mercado>> ListarAtivosAsync();
        Task<IEnumerable<Mercado>> BuscarPorNomeAsync(string nome);
    }
}
