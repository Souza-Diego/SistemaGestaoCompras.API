using SistemaGestaoCompras.Application.DTOs.Produtos;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Produtos
{
    public class AlterarMarcaProdutoUseCase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public AlterarMarcaProdutoUseCase(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task ExecutarAsync(AlterarMarcaProdutoDto dto)
        {
            var produto = await _produtoRepositorio.BuscarPorIdAsync(dto.Id);

            if (produto == null)
                throw new Exception("Produto não encontrado.");

            produto.AlterarMarca(dto.NovaMarcaId);

            await _produtoRepositorio.AtualizarAsync(produto);
        }
    }
}