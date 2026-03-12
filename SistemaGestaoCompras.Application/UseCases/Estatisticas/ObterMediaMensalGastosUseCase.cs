using SistemaGestaoCompras.Application.DTOs.Estatisticas;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Estatisticas
{
    public class ObterMediaMensalGastosUseCase
    {
        private readonly ICompraRepositorio _compraRepositorio;

        public ObterMediaMensalGastosUseCase(ICompraRepositorio compraRepositorio)
        {
            _compraRepositorio = compraRepositorio;
        }

        public async Task<MediaMensalGastosDto> ExecutarAsync(Guid usuarioId)
        {
            var compras = await _compraRepositorio.ObterPorUsuarioAsync(usuarioId);

            var comprasFinalizadas = compras.Where(c => c.Finalizada);

            var total = comprasFinalizadas.Sum(c => c.CalcularValorTotal().Valor);

            var meses = comprasFinalizadas
                .Select(c => new { c.DataCompra.Year, c.DataCompra.Month })
                .Distinct()
                .Count();

            if (meses == 0)
                return new MediaMensalGastosDto { MediaMensal = 0 };

            return new MediaMensalGastosDto
            {
                MediaMensal = total / meses
            };
        }
    }
}