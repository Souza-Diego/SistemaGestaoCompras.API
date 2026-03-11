using SistemaGestaoCompras.Application.DTOs.Produtos;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Produtos
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