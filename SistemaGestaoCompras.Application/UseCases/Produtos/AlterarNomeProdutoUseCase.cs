using SistemaGestaoCompras.Application.DTOs.Produtos;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Produtos
{
    public class AlterarNomeProdutoUseCase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public AlterarNomeProdutoUseCase(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task ExecutarAsync(AlterarNomeProdutoDto dto)
        {
            var produto = await _produtoRepositorio.BuscarPorIdAsync(dto.Id);

            if (produto == null)
                throw new Exception("Produto não encontrado.");

            produto.AlterarNome(dto.NovoNome);

            await _produtoRepositorio.AtualizarAsync(produto);
        }
    }
}