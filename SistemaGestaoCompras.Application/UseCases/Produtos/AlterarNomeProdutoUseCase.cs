using SistemaGestaoCompras.Application.DTOs.Produtos;
using SistemaGestaoCompras.Domain.Exceptions;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Produtos
{
    public class AlterarNomeProdutoUseCase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public AlterarNomeProdutoUseCase(
            IProdutoRepositorio produtoRepositorio,
            IUsuarioRepositorio usuarioRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task ExecutarAsync(AlterarNomeProdutoDto dto)
        {
            var produto = await _produtoRepositorio.BuscarPorIdAsync(dto.Id);

            if (produto == null)
                throw new AppNotFoundException("Produto não encontrado.");

            var usuario = await _usuarioRepositorio.BuscarPorIdAsync(dto.UsuarioId);

            if (usuario == null)
                throw new AppNotFoundException("Usuário não encontrado.");

            if (produto.IsGlobal() && !usuario.IsADM())
                throw new AppDomainException("Somente administradores podem alterar produtos globais.");

            var existeDuplicado = await _produtoRepositorio
                .ExisteProdutoDuplicadoAsync(
                    dto.NovoNome,
                    produto.IdMarca,
                    produto.UnidadeBase.Simbolo,
                    produto.QuantidadeBase,
                    produto.Id
                );

            if (existeDuplicado)
                throw new AppDomainException("Já existe um produto com o mesmo nome, marca e unidade.");

            produto.AlterarNome(dto.NovoNome, dto.UsuarioId);

            await _produtoRepositorio.AtualizarAsync(produto);
        }
    }
}