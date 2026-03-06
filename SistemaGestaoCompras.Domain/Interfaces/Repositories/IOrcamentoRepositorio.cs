using SistemaGestaoCompras.Domain.Entities;

namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IOrcamentoRepositorio
    {
        Task<Orcamento?> ObterPorUsuarioMesAsync(Guid idUsuario, int ano, int mes);
        Task<IEnumerable<Orcamento>> ObterPorUsuarioAsync(Guid usuarioId);        
        Task AdicionarAsync(Orcamento orcamento);
        Task AtualizarAsync(Orcamento orcamento);
    }
}
