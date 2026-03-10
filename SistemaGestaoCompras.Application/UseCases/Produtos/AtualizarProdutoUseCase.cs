using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Application.DTOs.Produtos;

namespace SistemaGestaoCompras.Application.UseCases.Produtos
{
    public class AtualizarProdutoUseCase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public AtualizarProdutoUseCase(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task ExecutarAsync(AtualizarProdutoDto dto)
        {
            var produto = await _produtoRepositorio.BuscarPorIdAsync(dto.Id);
            if(produto == null)
            {
                throw new Exception("Produto não encontrado");
            }

            produto.AlterarNome(dto.Nome);
            produto.AlterarCategoria(dto.IdCategoria);
            produto.AlterarMarca(dto.IdMarca);
            await _produtoRepositorio.AtualizarAsync(produto);
        }
    }
}
