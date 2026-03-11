using SistemaGestaoCompras.Application.DTOs.Compras;
using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Compras;

public class ListarComprasPorPeriodoUseCase
{
    private readonly ICompraRepositorio _repositorio;

    public ListarComprasPorPeriodoUseCase(ICompraRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<IEnumerable<Compra>> ExecutarAsync(ListarComprasPeriodoDto dto)
    {
        return await _repositorio.ObterPorPeriodoAsync(
            dto.IdUsuario,
            dto.DataInicio,
            dto.DataFim
        );
    }
}