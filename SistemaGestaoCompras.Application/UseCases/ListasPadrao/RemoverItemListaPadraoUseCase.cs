using SistemaGestaoCompras.Application.DTOs.ListasPadrao;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

public class RemoverItemListaPadraoUseCase
{
    private readonly IListaDeComprasPadraoRepositorio _repositorio;

    public RemoverItemListaPadraoUseCase(IListaDeComprasPadraoRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task ExecutarAsync(RemoverItemListaPadraoDto dto)
    {
        var lista = await _repositorio.BuscarPorIdAsync(dto.IdListaPadrao);

        if (lista == null)
            throw new Exception("Lista padrão não encontrada");

        lista.RemoverItem(dto.IdProduto);

        await _repositorio.AtualizarAsync(lista);
    }
}