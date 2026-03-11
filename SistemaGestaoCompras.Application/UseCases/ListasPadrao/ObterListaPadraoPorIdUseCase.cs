using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

public class ObterListaPadraoPorIdUseCase
{
    private readonly IListaDeComprasPadraoRepositorio _repositorio;

    public ObterListaPadraoPorIdUseCase(IListaDeComprasPadraoRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<ListaDeCompraPadrao?> ExecutarAsync(Guid id)
    {
        return await _repositorio.BuscarPorIdAsync(id);
    }
}