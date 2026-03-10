using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

public class ListarListasDeComprasUseCase
{
    private readonly IListaDeComprasRepositorio _listaRepositorio;

    public ListarListasDeComprasUseCase(IListaDeComprasRepositorio listaRepositorio)
    {
        _listaRepositorio = listaRepositorio;
    }

    public async Task<IEnumerable<ListaDeCompra>> ExecutarAsync()
    {
        return await _listaRepositorio.BuscarTodosAsync();
    }
}