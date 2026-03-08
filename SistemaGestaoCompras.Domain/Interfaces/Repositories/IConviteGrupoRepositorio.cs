using SistemaGestaoCompras.Domain.Entities;
namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IConviteGrupoRepositorio : IRepositorioBase<ConviteGrupo>
    {
        Task<ConviteGrupo?> ObterPorCodigoAsync(string codigo);        
    }
}
