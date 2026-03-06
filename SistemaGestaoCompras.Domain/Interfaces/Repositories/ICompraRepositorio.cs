using SistemaGestaoCompras.Domain.Entities;

namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface ICompraRepositorio
    {
        Task<Compra?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Compra>> ObterPorUsuarioAsync(Guid usuarioId);
        Task<IEnumerable<Compra>> ObterPorPeriodoAsync(Guid idUsuario, DateTime inicio, DateTime fim);
        Task AdicionarAsync(Compra compra);
        Task AtualizarAsync(Compra compra);        
    }
}
