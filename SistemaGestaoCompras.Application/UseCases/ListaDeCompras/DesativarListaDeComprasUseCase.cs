using SistemaGestaoCompras.Domain.Interfaces.Repositories;

public class DesativarListaDeComprasUseCase
{
    private readonly IListaDeComprasRepositorio _listaRepositorio;

    public DesativarListaDeComprasUseCase(IListaDeComprasRepositorio listaRepositorio)
    {
        _listaRepositorio = listaRepositorio;
    }

    public async Task ExecutarAsync(Guid id)
    {
        await _listaRepositorio.RemoverAsync(id);
    }
}
