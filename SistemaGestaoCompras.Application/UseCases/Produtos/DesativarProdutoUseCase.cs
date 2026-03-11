using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Produtos
{
    public class DesativarProdutoUseCase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public DesativarProdutoUseCase(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task ExecutarAsync(Guid id)
        {
            var produto = await _produtoRepositorio.BuscarPorIdAsync(id);

            if (produto == null)
                throw new Exception("Produto não encontrado.");

            produto.DesativarProduto();

            await _produtoRepositorio.AtualizarAsync(produto);
        }
    }
}