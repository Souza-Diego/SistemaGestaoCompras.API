using SistemaGestaoCompras.Domain.Entities;

namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface ICompraRepositorio : IRepositorioBase<Compra>
    {
        Task<IEnumerable<Compra>> ObterPorUsuarioAsync(Guid usuarioId);
        Task<IEnumerable<Compra>> ObterPorPeriodoAsync(Guid idUsuario, DateTime inicio, DateTime fim);
               
    }
}
