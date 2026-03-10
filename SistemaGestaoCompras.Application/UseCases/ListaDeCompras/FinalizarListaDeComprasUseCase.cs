using SistemaGestaoCompras.Domain.Interfaces.Repositories;

public class FinalizarListaDeComprasUseCase
{
    private readonly IListaDeComprasRepositorio _listaRepositorio;

    public FinalizarListaDeComprasUseCase(IListaDeComprasRepositorio listaRepositorio)
    {
        _listaRepositorio = listaRepositorio;
    }

    public async Task ExecutarAsync(Guid idLista)
    {
        var lista = await _listaRepositorio.BuscarPorIdAsync(idLista);

        if (lista == null)
            throw new Exception("Lista de compras não encontrada.");

        lista.Finalizar();

        await _listaRepositorio.AtualizarAsync(lista);
    }
}