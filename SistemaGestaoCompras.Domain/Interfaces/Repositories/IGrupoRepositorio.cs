using SistemaGestaoCompras.Domain.Entities;
namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IGrupoRepositorio
    {
        Task<Grupo?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Grupo>> ObterPorUsuarioAsync(Guid usuarioId);
        Task AdicionarAsync(Grupo grupo);
        Task AtualizarAsync(Grupo grupo);
    }
}
