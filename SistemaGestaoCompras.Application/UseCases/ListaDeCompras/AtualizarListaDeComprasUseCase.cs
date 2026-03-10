using SistemaGestaoCompras.Application.DTOs.ListaDeCompras;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

public class AtualizarListaDeComprasUseCase
{
    private readonly IListaDeComprasRepositorio _listaRepositorio;

    public AtualizarListaDeComprasUseCase(IListaDeComprasRepositorio listaRepositorio)
    {
        _listaRepositorio = listaRepositorio;
    }

    public async Task ExecutarAsync(AtualizarListaComprasDto dto)
    {
        var lista = await _listaRepositorio.BuscarPorIdAsync(dto.Id);

        if (lista == null)
            throw new Exception("Lista não encontrada");

        lista.AlterarNome(dto.Nome);

        await _listaRepositorio.AtualizarAsync(lista);
    }
}