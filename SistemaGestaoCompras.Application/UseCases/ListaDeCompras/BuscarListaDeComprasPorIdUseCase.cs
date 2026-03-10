using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

public class BuscarListaDeComprasPorIdUseCase
{
    private readonly IListaDeComprasRepositorio _listaRepositorio;

    public BuscarListaDeComprasPorIdUseCase(IListaDeComprasRepositorio listaRepositorio)
    {
        _listaRepositorio = listaRepositorio;
    }

    public async Task<ListaDeCompra?> ExecutarAsync(Guid id)
    {
        return await _listaRepositorio.BuscarPorIdAsync(id);
    }
}
