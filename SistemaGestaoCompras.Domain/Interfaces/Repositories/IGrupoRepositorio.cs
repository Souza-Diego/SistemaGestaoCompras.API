using SistemaGestaoCompras.Domain.Entities;
namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IGrupoRepositorio : IRepositorioBase<Grupo>
    {        
        Task<IEnumerable<Grupo>> ObterPorUsuarioAsync(Guid usuarioId);        
    }
}
