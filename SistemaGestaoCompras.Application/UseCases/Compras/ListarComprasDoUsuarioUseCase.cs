using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Compras;

public class ListarComprasDoUsuarioUseCase
{
    private readonly ICompraRepositorio _repositorio;

    public ListarComprasDoUsuarioUseCase(ICompraRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<IEnumerable<Compra>> ExecutarAsync(Guid usuarioId)
    {
        return await _repositorio.ObterPorUsuarioAsync(usuarioId);
    }
}