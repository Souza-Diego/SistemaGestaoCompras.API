using SistemaGestaoCompras.Domain.Entities;
namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IRegistroDePrecoRepositorio : IRepositorioBase<RegistroDePreco>
    {
        Task<IEnumerable<RegistroDePreco>> ObterPorProdutoAsync(Guid produtoId);
        Task<IEnumerable<RegistroDePreco>> ObterPorUsuarioAsync(Guid usuarioId);        
    }
}
