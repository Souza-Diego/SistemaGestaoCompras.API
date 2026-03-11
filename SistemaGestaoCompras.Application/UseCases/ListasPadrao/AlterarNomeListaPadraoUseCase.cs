using SistemaGestaoCompras.Application.DTOs.ListasPadrao;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

public class AlterarNomeListaPadraoUseCase
{
    private readonly IListaDeComprasPadraoRepositorio _repositorio;

    public AlterarNomeListaPadraoUseCase(IListaDeComprasPadraoRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task ExecutarAsync(AlterarNomeListaPadraoDto dto)
    {
        var lista = await _repositorio.BuscarPorIdAsync(dto.Id);

        if (lista == null)
            throw new Exception("Lista padrão não encontrada");

        lista.AlterarNome(dto.NovoNome);

        await _repositorio.AtualizarAsync(lista);
    }
}