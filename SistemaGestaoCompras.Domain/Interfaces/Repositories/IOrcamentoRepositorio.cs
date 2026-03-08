using SistemaGestaoCompras.Domain.Entities;

namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IOrcamentoRepositorio : IRepositorioBase<Orcamento>
    {
        Task<Orcamento?> ObterPorUsuarioMesAsync(Guid idUsuario, int ano, int mes);
        Task<IEnumerable<Orcamento>> ObterPorUsuarioAsync(Guid usuarioId);        
    }
}
