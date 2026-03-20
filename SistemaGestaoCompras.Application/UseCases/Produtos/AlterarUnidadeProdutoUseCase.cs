using SistemaGestaoCompras.Application.DTOs.Produtos;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.ValueObjects;
using SistemaGestaoCompras.Domain.Exceptions;

namespace SistemaGestaoCompras.Application.UseCases.Produtos
{
    public class AlterarUnidadeProdutoUseCase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public AlterarUnidadeProdutoUseCase(
            IProdutoRepositorio produtoRepositorio,
            IUsuarioRepositorio usuarioRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task ExecutarAsync(AlterarUnidadeProdutoDto dto)
        {
            var produto = await _produtoRepositorio.BuscarPorIdAsync(dto.Id);

            if (produto == null)
                throw new AppNotFoundException("Produto não encontrado.");

            var usuario = await _usuarioRepositorio.BuscarPorIdAsync(dto.UsuarioId);

            if (usuario == null)
                throw new AppNotFoundException("Usuário não encontrado.");

            if (produto.IsGlobal() && !usuario.IsADM())
                throw new AppDomainException("Somente administradores podem alterar produtos globais.");

            var novaUnidade = UnidadeMedida.ObterPorSimbolo(dto.NovaUnidade);

            var existeDuplicado = await _produtoRepositorio
                .ExisteProdutoDuplicadoAsync(
                produto.Nome,
                produto.IdMarca,
                novaUnidade.Simbolo,
                produto.QuantidadeBase,
                produto.Id);

            if (existeDuplicado)
                throw new AppDomainException("Já existe um produto com o mesmo nome, marca e unidade.");

            produto.AlterarUnidade(novaUnidade, dto.UsuarioId);

            await _produtoRepositorio.AtualizarAsync(produto);
        }
    }
}