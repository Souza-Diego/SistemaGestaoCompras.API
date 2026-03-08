using SistemaGestaoCompras.Domain.Entities;
namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IListaDeComprasRepositorio : IRepositorioBase<ListaDeCompras>
    {        
        Task<IEnumerable<ListaDeCompras>> ObterPorUsuarioAsync(Guid usuarioId);
        Task<IEnumerable<ListaDeCompras>> ObterPorGrupoAsync(Guid idGrupo);        
    }
}
