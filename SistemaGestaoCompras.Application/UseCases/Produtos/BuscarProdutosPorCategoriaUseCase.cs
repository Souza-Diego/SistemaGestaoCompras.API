using SistemaGestaoCompras.Application.DTOs.Produtos;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Produtos
{
    public class BuscarProdutosPorCategoriaUseCase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public BuscarProdutosPorCategoriaUseCase(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task<IEnumerable<ProdutoDto>> ExecutarAsync(Guid categoriaId)
        {
            var produtos = await _produtoRepositorio.ObterPorCategoriaAsync(categoriaId);

            return produtos.Select(produto => new ProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                IdCategoria = produto.IdCategoria,
                IdMarca = produto.IdMarca,
                UnidadeBase = produto.UnidadeBase.Simbolo,
                Tipo = produto.Tipo.ToString(),
                Ativo = produto.Ativo
            });
        }
    }
}
