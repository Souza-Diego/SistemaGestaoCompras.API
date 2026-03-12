using Microsoft.AspNetCore.Mvc;
using SistemaGestaoCompras.Application.UseCases.Estatisticas;

namespace SistemaGestaoCompras.API.Controllers
{
    [Route("api/[controller]")]
    public class EstatisticasController : BaseController
    {
        private readonly ObterGastosPorCategoriaUseCase _gastosCategoria;
        private readonly ObterGastosMensaisUseCase _gastosMensais;
        private readonly ObterMediaMensalGastosUseCase _mediaMensal;

        public EstatisticasController(
            ObterGastosPorCategoriaUseCase gastosCategoria,
            ObterGastosMensaisUseCase gastosMensais,
            ObterMediaMensalGastosUseCase mediaMensal)
        {
            _gastosCategoria = gastosCategoria;
            _gastosMensais = gastosMensais;
            _mediaMensal = mediaMensal;
        }

        [HttpGet("gastos-por-categoria/{usuarioId}")]
        public async Task<IActionResult> GastosPorCategoria(Guid usuarioId)
        {
            var resultado = await _gastosCategoria.ExecutarAsync(usuarioId);
            return OkResponse(resultado);
        }

        [HttpGet("gastos-mensais/{usuarioId}")]
        public async Task<IActionResult> GastosMensais(Guid usuarioId)
        {
            var resultado = await _gastosMensais.ExecutarAsync(usuarioId);
            return OkResponse(resultado);
        }

        [HttpGet("media-mensal/{usuarioId}")]
        public async Task<IActionResult> MediaMensal(Guid usuarioId)
        {
            var resultado = await _mediaMensal.ExecutarAsync(usuarioId);
            return OkResponse(resultado);
        }
    }
}