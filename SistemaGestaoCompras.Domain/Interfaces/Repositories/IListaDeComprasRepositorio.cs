using SistemaGestaoCompras.Domain.Entities;
namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IListaDeComprasRepositorio
    {
        Task<ListaDeCompras?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<ListaDeCompras>> ObterPorUsuarioAsync(Guid usuarioId);
        Task<IEnumerable<ListaDeCompras>> ObterPorGrupoAsync(Guid idGrupo);
        Task AdicionarAsync(ListaDeCompras lista);
        Task AtualizarAsync(ListaDeCompras lista);
    }
}
