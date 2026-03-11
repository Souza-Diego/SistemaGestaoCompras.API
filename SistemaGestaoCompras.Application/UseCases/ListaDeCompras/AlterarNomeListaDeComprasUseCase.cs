using SistemaGestaoCompras.Application.DTOs.ListaDeCompras;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

public class AlterarNomeListaDeComprasUseCase
{
    private readonly IListaDeComprasRepositorio _listaRepositorio;

    public AlterarNomeListaDeComprasUseCase(IListaDeComprasRepositorio listaRepositorio)
    {
        _listaRepositorio = listaRepositorio;
    }

    public async Task ExecutarAsync(AlterarNomeListaComprasDto dto)
    {
        var lista = await _listaRepositorio.BuscarPorIdAsync(dto.Id);

        if (lista == null)
            throw new Exception("Lista não encontrada");

        lista.AlterarNome(dto.Nome);

        await _listaRepositorio.AtualizarAsync(lista);
    }
}