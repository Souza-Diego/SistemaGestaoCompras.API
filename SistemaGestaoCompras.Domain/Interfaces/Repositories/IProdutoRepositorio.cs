using SistemaGestaoCompras.Domain.Entities;
namespace SistemaGestaoCompras.Domain.Interfaces.Repositories
{
    public interface IProdutoRepositorio : IRepositorioBase<Produto>
    {        
        Task<IEnumerable<Produto>> ObterPorCategoriaAsync(Guid categoria);
        Task<IEnumerable<Produto>> BuscarPorNomeAsync(string nome);
        Task<IEnumerable<Produto>> ListarAtivosAsync();
        Task<bool> ExisteProdutoDuplicadoAsync(
            string nome, 
            Guid? idMarca, 
            string simboloUnidade, 
            decimal? quantidadeBase,
            Guid? ignorarProdutoId = null);
        Task<IEnumerable<Produto>> ListarPorUsuarioAsync(Guid usuarioId);
    }
}
