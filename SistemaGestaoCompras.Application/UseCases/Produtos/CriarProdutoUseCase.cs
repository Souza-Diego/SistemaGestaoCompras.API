using SistemaGestaoCompras.Application.DTOs.Produtos;
using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.Enums;
using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.Application.UseCases.Produtos
{
    public class CriarProdutoUseCase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public CriarProdutoUseCase(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task<Guid> ExecutarAsync(CriarProdutoDto dto)
        {
            var unidade = ObterUnidade(dto.UnidadeBase);
            var produto = new Produto(
                dto.Nome,
                dto.IdCategoria,
                unidade,
                TipoProduto.Personalizado,
                dto.IdMarca);

            await _produtoRepositorio.AdicionarAsync(produto);
            return produto.Id;
        }

        private UnidadeMedida ObterUnidade(string unidade)
        {
            return unidade.ToLower() switch
            {
                "g" => UnidadeMedida.Grama,
                "kg" => UnidadeMedida.Quilograma,
                "ml" => UnidadeMedida.Mililitro,
                "l" => UnidadeMedida.Litro,
                "un" => UnidadeMedida.Unidade,
                _ => throw new Exception("Unidade inválida")
            };
        }
    }
}
