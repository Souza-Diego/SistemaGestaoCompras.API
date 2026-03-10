using SistemaGestaoCompras.Application.DTOs.Produtos;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Produtos
{
    public class BuscarProdutoPorIdUseCase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public BuscarProdutoPorIdUseCase(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task<ProdutoDto?> ExecutarAsync(Guid id)
        {
            var produto = await _produtoRepositorio.BuscarPorIdAsync(id);

            if (produto == null)
                return null;

            return new ProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                IdCategoria = produto.IdCategoria,
                IdMarca = produto.IdMarca,
                UnidadeBase = produto.UnidadeBase.ToString(),
                Tipo = produto.Tipo.ToString(),
                Ativo = produto.Ativo
            };
        }
    }
}