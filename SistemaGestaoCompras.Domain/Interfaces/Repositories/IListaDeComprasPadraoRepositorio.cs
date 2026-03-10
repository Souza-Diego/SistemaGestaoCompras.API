using SistemaGestaoCompras.Domain.Entities;

namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IListaDeComprasPadraoRepositorio : IRepositorioBase<ListaDeCompraPadrao>
    {        
        Task<IEnumerable<ListaDeCompraPadrao>> ObterPorUsuarioAsync(Guid usuarioId);        
    }
}
