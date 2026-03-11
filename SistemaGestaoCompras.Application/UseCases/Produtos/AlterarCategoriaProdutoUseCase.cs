using SistemaGestaoCompras.Application.DTOs.Produtos;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Produtos
{
    public class AlterarCategoriaProdutoUseCase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public AlterarCategoriaProdutoUseCase(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task ExecutarAsync(AlterarCategoriaProdutoDto dto)
        {
            var produto = await _produtoRepositorio.BuscarPorIdAsync(dto.Id);

            if (produto == null)
                throw new Exception("Produto não encontrado.");

            produto.AlterarCategoria(dto.NovaCategoriaId);

            await _produtoRepositorio.AtualizarAsync(produto);
        }
    }
}