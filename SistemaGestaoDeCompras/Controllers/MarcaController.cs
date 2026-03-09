using Microsoft.AspNetCore.Mvc;
using SistemaGestaoCompras.Application.UseCases.Marcas;
using SistemaGestaoCompras.Application.DTOs.Marcas;

namespace SistemaGestaoCompras.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcaController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Criar(
            [FromServices] CriarMarcaUseCase criarMarca,
            [FromBody] CriarMarcaDto dto)
        {
            var id = await criarMarca.ExecutarAsync(dto);
            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> Listar(
            [FromServices] ListarMarcasUseCase listarMarcas)
        {
            var marcas = await listarMarcas.ExecutarAsync();
            return Ok(marcas);
        }

        [HttpPut]
        public async Task<IActionResult> Dexativar(
            [FromServices] DesativarMarcaUseCase desativarMarca,
            Guid id)
        {
            await desativarMarca.ExecutarAsync(id);
            return NoContent();
        }
    }
}
