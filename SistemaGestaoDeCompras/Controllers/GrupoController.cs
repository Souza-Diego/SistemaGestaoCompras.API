using Microsoft.AspNetCore.Mvc;
using SistemaGestaoCompras.Application.UseCases.Grupos;
using SistemaGestaoCompras.Application.DTOs.Grupos;

namespace SistemaGestaoCompras.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GrupoController : ControllerBase
    {
        private readonly CriarGrupoUseCase _criarGrupoUseCase;
        private readonly RemoverMembroGrupoUseCase _removerMembroGrupoUseCase;

        public GrupoController(
            CriarGrupoUseCase criarGrupoUseCase,
            RemoverMembroGrupoUseCase removerMembroGrupoUseCase)
        {
            _criarGrupoUseCase = criarGrupoUseCase;
            _removerMembroGrupoUseCase = removerMembroGrupoUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarGrupoDto dto)
        {
            var IdGrupo = await _criarGrupoUseCase.ExecutarAsync(dto);

            return Ok(IdGrupo);
        }

        [HttpDelete("{idGrupo}/membros/{idUsuarioRemover}")]
        public async Task<IActionResult> RemoverMembro(
            Guid idGrupo,
            Guid idUsuarioRemover,
            [FromQuery] Guid idUsuarioSolicitante)
        {
            var dto = new RemoverMembroGrupoDto
            {
                IdGrupo = idGrupo,
                IdUsuarioRemover = idUsuarioRemover,
                IdUsuarioSolicitante = idUsuarioSolicitante
            };

            await _removerMembroGrupoUseCase.ExecutarAsync(dto);
            return NoContent();
        }
    }
}
