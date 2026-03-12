using SistemaGestaoCompras.Application.DTOs.Estatisticas;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Estatisticas
{
    public class ObterGastosMensaisUseCase
    {
        private readonly ICompraRepositorio _compraRepositorio;

        public ObterGastosMensaisUseCase(ICompraRepositorio compraRepositorio)
        {
            _compraRepositorio = compraRepositorio;
        }

        public async Task<IEnumerable<GastosMensaisDto>> ExecutarAsync(Guid usuarioId)
        {
            var compras = await _compraRepositorio.ObterPorUsuarioAsync(usuarioId);

            var resultado = compras
                .Where(c => c.Finalizada)
                .GroupBy(c => new { c.DataCompra.Year, c.DataCompra.Month })
                .Select(g => new GastosMensaisDto
                {
                    Ano = g.Key.Year,
                    Mes = g.Key.Month,
                    ValorTotal = g.Sum(c => c.CalcularValorTotal().Valor)
                });

            return resultado;
        }
    }
}