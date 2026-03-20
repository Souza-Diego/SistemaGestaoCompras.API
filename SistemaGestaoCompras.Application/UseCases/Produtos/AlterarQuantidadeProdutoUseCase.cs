using SistemaGestaoCompras.Application.DTOs.Produtos;
using SistemaGestaoCompras.Domain.Exceptions;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

public class AlterarQuantidadeProdutoUseCase
{
    private readonly IProdutoRepositorio _produtoRepositorio;
    private readonly IUsuarioRepositorio _usuarioRepositorio;

    public AlterarQuantidadeProdutoUseCase(
        IProdutoRepositorio produtoRepositorio,
        IUsuarioRepositorio usuarioRepositorio)
    {
        _produtoRepositorio = produtoRepositorio;
        _usuarioRepositorio = usuarioRepositorio;
    }

    public async Task ExecutarAsync(AlterarQuantidadeProdutoDto dto)
    {
        var produto = await _produtoRepositorio.BuscarPorIdAsync(dto.Id);

        if (produto == null)
            throw new AppNotFoundException("Produto não encontrado.");

        var usuario = await _usuarioRepositorio.BuscarPorIdAsync(dto.UsuarioId);

        if (usuario == null)
            throw new AppNotFoundException("Usuário não encontrado.");

        if (produto.IsGlobal() && !usuario.IsADM())
            throw new AppDomainException("Somente administradores podem alterar produtos globais.");

        if (dto.NovaQuantidade.HasValue && dto.NovaQuantidade <= 0)
            throw new AppDomainException("Quantidade deve ser maior que zero.");

        var existeDuplicado = await _produtoRepositorio
            .ExisteProdutoDuplicadoAsync(
                produto.Nome,
                produto.IdMarca,
                produto.UnidadeBase.Simbolo,
                dto.NovaQuantidade,
                produto.Id
            );

        if (existeDuplicado)
            throw new AppDomainException("Já existe um produto com o mesmo nome, marca, unidade e quantidade.");

        produto.AlterarQuantidade(dto.NovaQuantidade, dto.UsuarioId);

        await _produtoRepositorio.AtualizarAsync(produto);
    }
}