using SistemaGestaoCompras.Application.DTOs.Produtos;
using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Enums;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
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
            var unidade = UnidadeMedida.ObterPorSimbolo(dto.UnidadeBase);

            var produto = new Produto(
                dto.Nome,
                dto.IdCategoria,
                unidade,
                TipoProduto.Personalizado,
                dto.IdMarca
            );

            await _produtoRepositorio.AdicionarAsync(produto);

            return produto.Id;
        }
    }
}