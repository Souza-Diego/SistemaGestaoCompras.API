using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.Exceptions;

namespace SistemaGestaoCompras.Application.UseCases.Produtos
{
    public class ReativarProdutoUseCase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public ReativarProdutoUseCase(
            IProdutoRepositorio produtoRepositorio,
            IUsuarioRepositorio usuarioRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task ExecutarAsync(Guid id, Guid usuarioId)
        {
            var produto = await _produtoRepositorio.BuscarPorIdAsync(id);

            if (produto == null)
                throw new AppNotFoundException("Produto não encontrado.");

            var usuario = await _usuarioRepositorio.BuscarPorIdAsync(usuarioId);

            if (usuario == null)
                throw new AppNotFoundException("Usuário não encontrado.");

            if (produto.IsGlobal() && !usuario.IsADM())
                throw new AppDomainException("Somente administradores podem reativar produtos globais.");

            produto.Ativar(usuarioId);

            await _produtoRepositorio.AtualizarAsync(produto);
        }
    }
}