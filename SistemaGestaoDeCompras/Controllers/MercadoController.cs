using Microsoft.AspNetCore.Mvc;
using SistemaGestaoCompras.Application.UseCases.Mercados;
using SistemaGestaoCompras.Application.DTOs.Mercados;

namespace SistemaGestaoCompras.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MercadoController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Criar(
            [FromServices] CriarMercadoUseCase criarMercado,
            [FromBody] CriarMercadoDto dto)
        {
            var id = await criarMercado.ExecutarAsync(dto);
            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> Listar(
            [FromServices] ListarMercadosUseCase listarMercados)
        {
            var mercados = await listarMercados.ExecutarAsync();
            return Ok(mercados);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar(
            [FromServices] AtualizarMercadoUseCase atualizarMercado,
            [FromBody] AtualizarMercadoDto dto)
        {
            await atualizarMercado.ExecutarAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Desativar(
            [FromServices] DesativarMercadoUseCase desativarMercado,
            Guid id)
        {
            await desativarMercado.ExecutarAsync(id);
            return NoContent();
        }

    }
}
