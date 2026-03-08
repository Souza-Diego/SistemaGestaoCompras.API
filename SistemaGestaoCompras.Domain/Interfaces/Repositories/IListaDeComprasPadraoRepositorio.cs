using SistemaGestaoCompras.Domain.Entities;

namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IListaDeComprasPadraoRepositorio : IRepositorioBase<ListaDeComprasPadrao>
    {        
        Task<IEnumerable<ListaDeComprasPadrao>> ObterPorUsuarioAsync(Guid usuarioId);        
    }
}
