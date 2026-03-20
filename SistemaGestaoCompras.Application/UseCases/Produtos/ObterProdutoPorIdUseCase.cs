using SistemaGestaoCompras.Application.DTOs.Produtos;
using SistemaGestaoCompras.Domain.Exceptions;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Produtos
{
    public class ObterProdutoPorIdUseCase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ObterProdutoPorIdUseCase(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task<ProdutoDto> ExecutarAsync(Guid id, Guid usuarioId)
        {
            var produto = await _produtoRepositorio.BuscarPorIdAsync(id);

            if (produto == null)
                throw new AppNotFoundException("Produto não encontrado.");

            if (produto.IsPersonalizado() && produto.IdCriadoPorUsuario != usuarioId)
                throw new AppDomainException("Você não tem permissão para acessar este produto.");

            return new ProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                IdCategoria = produto.IdCategoria,
                IdMarca = produto.IdMarca,
                UnidadeBase = produto.UnidadeBase.Simbolo,
                Tipo = produto.Tipo.ToString(),
                Ativo = produto.Ativo,
                QuantidadeBase = produto.QuantidadeBase
            };
        }
    }
}