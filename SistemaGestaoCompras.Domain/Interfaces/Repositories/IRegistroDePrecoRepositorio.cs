using SistemaGestaoCompras.Domain.Entities;
namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IRegistroDePrecoRepositorio
    {
        Task<IEnumerable<RegistroDePreco>> ObterPorProdutoAsync(Guid produtoId);
        Task<IEnumerable<RegistroDePreco>> ObterPorUsuarioAsync(Guid usuarioId);
        Task AdicionarAsync(RegistroDePreco registro);
        Task AtualizarAsync(RegistroDePreco registro);
    }
}
