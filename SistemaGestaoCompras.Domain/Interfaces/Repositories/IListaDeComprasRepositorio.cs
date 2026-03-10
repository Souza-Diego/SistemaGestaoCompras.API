using SistemaGestaoCompras.Domain.Entities;
namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IListaDeComprasRepositorio : IRepositorioBase<ListaDeCompra>
    {        
        Task<IEnumerable<ListaDeCompra>> ListarPorUsuarioIdAsync(Guid idUsuario);
        Task<IEnumerable<ListaDeCompra>> ListarPorGrupoIdAsync(Guid idGrupo);        
    }
}
