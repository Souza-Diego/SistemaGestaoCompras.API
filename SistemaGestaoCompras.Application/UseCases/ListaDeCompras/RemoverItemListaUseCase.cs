using SistemaGestaoCompras.Application.DTOs.ListaDeCompras;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

public class RemoverItemListaUseCase
{
    private readonly IListaDeComprasRepositorio _listaRepositorio;

    public RemoverItemListaUseCase(IListaDeComprasRepositorio listaRepositorio)
    {
        _listaRepositorio = listaRepositorio;
    }

    public async Task ExecutarAsync(RemoverItemListaDto dto)
    {
        var lista = await _listaRepositorio.BuscarPorIdAsync(dto.IdListaDeCompras);

        if (lista == null)
            throw new Exception("Lista de compras não encontrada.");

        lista.RemoverItem(dto.IdItem);

        await _listaRepositorio.AtualizarAsync(lista);
    }
}