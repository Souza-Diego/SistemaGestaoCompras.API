using SistemaGestaoCompras.Domain.Interfaces.Repositories;

public class ReabrirListaDeComprasUseCase
{
    private readonly IListaDeComprasRepositorio _listaRepositorio;

    public ReabrirListaDeComprasUseCase(IListaDeComprasRepositorio listaRepositorio)
    {
        _listaRepositorio = listaRepositorio;
    }

    public async Task ExecutarAsync(Guid idLista)
    {
        var lista = await _listaRepositorio.BuscarPorIdAsync(idLista);

        if (lista == null)
            throw new Exception("Lista de compras não encontrada.");

        lista.Reabrir();

        await _listaRepositorio.AtualizarAsync(lista);
    }
}