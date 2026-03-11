using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Compras;

public class ObterMercadosMaisUsadosUseCase
{
    private readonly ICompraRepositorio _repositorio;

    public ObterMercadosMaisUsadosUseCase(ICompraRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<IEnumerable<object>> ExecutarAsync(Guid usuarioId)
    {
        var compras = await _repositorio.ObterPorUsuarioAsync(usuarioId);

        return compras
            .GroupBy(c => c.IdMercado)
            .Select(g => new
            {
                MercadoId = g.Key,
                TotalCompras = g.Count()
            })
            .OrderByDescending(g => g.TotalCompras)
            .Take(5);
    }
}