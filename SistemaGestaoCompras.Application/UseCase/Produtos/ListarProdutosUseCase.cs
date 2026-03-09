using SistemaGestaoCompras.Application.DTOs.Produtos;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCase.Produtos
{
    public class ListarProdutosUseCase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ListarProdutosUseCase(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task<IEnumerable<ProdutoDto>> ExecutarAsync()
        {
            var produtos = await _produtoRepositorio.ListarAtivosAsync();

            return produtos.Select(p => new ProdutoDto{
                Id = p.Id,
                Nome = p.Nome,
                IdCategoria = p.IdCategoria,
                IdMarca = p.IdMarca,
                UnidadeBase = p.UnidadeBase.Simbolo,
                Ativo = p.Ativo
            });
        }
    }
}
