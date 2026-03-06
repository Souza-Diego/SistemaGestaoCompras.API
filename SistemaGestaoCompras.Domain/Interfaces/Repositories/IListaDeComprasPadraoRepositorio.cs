using SistemaGestaoCompras.Domain.Entities;

namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IListaDeComprasPadraoRepositorio
    {
        Task<ListaDeComprasPadrao?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<ListaDeComprasPadrao>> ObterPorUsuarioAsync(Guid usuarioId);
        Task AdicionarAsync(ListaDeComprasPadrao lista);
        Task AtualizarAsync(ListaDeComprasPadrao lista);
    }
}
