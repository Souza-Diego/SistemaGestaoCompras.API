using SistemaGestaoCompras.Domain.Entities;
namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IConviteGrupoRepositorio : IRepositorioBase<ConviteGrupo>
    {
        Task<ConviteGrupo?> BuscarPorCodigoAsync(string codigo);
        Task<List<ConviteGrupo>> ListarPorGrupoIdAsync(Guid grupoId);

    }
}
