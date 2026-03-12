using Microsoft.AspNetCore.Mvc;
using SistemaGestaoCompras.Application.DTOs.Orcamentos;
using SistemaGestaoCompras.Application.UseCases.Orcamentos;

namespace SistemaGestaoCompras.API.Controllers
{
    [ApiController]
    [Route("api/orcamentos")]
    public class OrcamentoController : ControllerBase
    {
        private readonly CriarOrcamentoMensalUseCase _criar;
        private readonly AlterarValorOrcamentoUseCase _alterar;
        private readonly ObterOrcamentoDoMesUseCase _obterMes;
        private readonly ListarOrcamentosUsuarioUseCase _listar;
        private readonly CalcularOrcamentoAutomaticoUseCase _calcularAuto;

        public OrcamentoController(
            CriarOrcamentoMensalUseCase criar,
            AlterarValorOrcamentoUseCase alterar,
            ObterOrcamentoDoMesUseCase obterMes,
            ListarOrcamentosUsuarioUseCase listar,
            CalcularOrcamentoAutomaticoUseCase calcularAuto)
        {
            _criar = criar;
            _alterar = alterar;
            _obterMes = obterMes;
            _listar = listar;
            _calcularAuto = calcularAuto;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarOrcamentoMensalDTO dto)
        {
            await _criar.ExecutarAsync(dto);
            return Ok();
        }

        [HttpPut("valor")]
        public async Task<IActionResult> AlterarValor([FromBody] AlterarValorOrcamentoDTO dto)
        {
            await _alterar.ExecutarAsync(dto);
            return Ok();
        }

        [HttpGet("mes")]
        public async Task<IActionResult> ObterMes(
            [FromQuery] Guid usuarioId,
            [FromQuery] int ano,
            [FromQuery] int mes)
        {
            var dto = new ObterOrcamentoDoMesDTO
            {
                IdUsuario = usuarioId,
                Ano = ano,
                Mes = mes
            };

            var resultado = await _obterMes.ExecutarAsync(dto);

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> ListarUsuario(Guid usuarioId)
        {
            var resultado = await _listar.ExecutarAsync(usuarioId);
            return Ok(resultado);
        }

        [HttpGet("calcular-automatico/{usuarioId}")]
        public async Task<IActionResult> CalcularAutomatico(Guid usuarioId)
        {
            var valor = await _calcularAuto.ExecutarAsync(usuarioId);
            return Ok(valor);
        }
    }
}