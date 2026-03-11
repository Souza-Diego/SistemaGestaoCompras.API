using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Compras;
public class ObterTotalGastoPorPeriodoUseCase
{
    private readonly ICompraRepositorio _repositorio;

    public ObterTotalGastoPorPeriodoUseCase(ICompraRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<decimal> ExecutarAsync(TotalGastoPeriodoDto dto)
    {
        var compras = await _repositorio.ObterPorPeriodoAsync(
            dto.IdUsuario,
            dto.Inicio,
            dto.Fim);

        return compras
            .Where(c => c.Finalizada && c.AtivaParaRelatorio)
            .Sum(c => c.ValorTotal.Valor);
    }
}