using SistemaGestaoCompras.Application.DTOs.Produtos;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Produtos
{
    public class ListarProdutosPorCategoriaUseCase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ListarProdutosPorCategoriaUseCase(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task<IEnumerable<ProdutoDto>> ExecutarAsync(Guid categoriaId, Guid usuarioId)
        {
            var produtos = await _produtoRepositorio.ListarPorUsuarioAsync(usuarioId);

            var filtrados = produtos.Where(p => p.IdCategoria == categoriaId);

            return filtrados.Select(produto => new ProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                IdCategoria = produto.IdCategoria,
                IdMarca = produto.IdMarca,
                UnidadeBase = produto.UnidadeBase.Simbolo,
                Tipo = produto.Tipo.ToString(),
                Ativo = produto.Ativo,
                QuantidadeBase = produto.QuantidadeBase
            });
        }
    }
}