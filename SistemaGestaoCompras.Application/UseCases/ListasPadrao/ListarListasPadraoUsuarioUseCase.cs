using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

public class ListarListasPadraoUsuarioUseCase
{
    private readonly IListaDeComprasPadraoRepositorio _repositorio;

    public ListarListasPadraoUsuarioUseCase(IListaDeComprasPadraoRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<IEnumerable<ListaDeCompraPadrao>> ExecutarAsync(Guid usuarioId)
    {
        return await _repositorio.ObterPorUsuarioAsync(usuarioId);
    }
}