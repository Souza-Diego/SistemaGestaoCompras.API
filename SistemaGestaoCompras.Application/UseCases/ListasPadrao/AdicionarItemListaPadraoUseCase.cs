using SistemaGestaoCompras.Application.DTOs.ListasPadrao;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.ValueObjects;

public class AdicionarItemListaPadraoUseCase
{
    private readonly IListaDeComprasPadraoRepositorio _repositorio;

    public AdicionarItemListaPadraoUseCase(IListaDeComprasPadraoRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task ExecutarAsync(AdicionarItemListaPadraoDto dto)
    {
        var lista = await _repositorio.BuscarPorIdAsync(dto.IdListaPadrao);

        if (lista == null)
            throw new Exception("Lista padrão não encontrada");

        var unidade = UnidadeMedida.ObterPorSimbolo(dto.Unidade);

        lista.AdicionarItem(dto.IdProduto, dto.QuantidadePlanejada, unidade);

        await _repositorio.AtualizarAsync(lista);
    }
}