using Microsoft.AspNetCore.Mvc;
using SistemaGestaoCompras.Application.DTOs.Convites;
using SistemaGestaoCompras.Application.UseCases.Convites;

namespace SistemaGestaoCompras.API.Controllers
{
    [Route("api/[controller]")]
    public class ConviteGrupoController : BaseController
    {
        private readonly CriarConviteGrupoUseCase _criarConviteUseCase;
        private readonly CancelarConviteGrupoUseCase _cancelarConviteUseCase;
        private readonly EntrarGrupoPorCodigoUseCase _entrarGrupoPorCodigoUseCase;
        private readonly ListarConvitesGrupoUseCase _listarConvitesUseCase;
        private readonly ValidarConviteGrupoUseCase _validarConviteUseCase;

        public ConviteGrupoController(
            CriarConviteGrupoUseCase criarConvite,
            CancelarConviteGrupoUseCase cancelarConvite,
            EntrarGrupoPorCodigoUseCase entrarGrupoPorCodigo,
            ListarConvitesGrupoUseCase listarConvites,
            ValidarConviteGrupoUseCase validarConvite)
        {
            _criarConviteUseCase = criarConvite;
            _cancelarConviteUseCase = cancelarConvite;
            _entrarGrupoPorCodigoUseCase = entrarGrupoPorCodigo;
            _listarConvitesUseCase = listarConvites;
            _validarConviteUseCase = validarConvite;
        }

        [HttpPost]
        public async Task<IActionResult> CriarConvite([FromBody] CriarConviteGrupoDto dto)
        {
            var id = await _criarConviteUseCase.ExecutarAsync(dto);

            return CreatedResponse(nameof(ListarPorGrupo), new { grupoId = dto.IdGrupo }, id);
        }

        [HttpPost("entrar")]
        public async Task<IActionResult> EntrarPorCodigo([FromBody] EntrarGrupoPorCodigoDto dto)
        {
            await _entrarGrupoPorCodigoUseCase.ExecutarAsync(dto);

            return NoContentResponse();
        }

        [HttpPost("validar")]
        public async Task<IActionResult> ValidarConvite([FromBody] ValidarConviteGrupoDto dto)
        {
            var valido = await _validarConviteUseCase.ExecutarAsync(dto);

            if (!valido)
                return NotFoundResponse();

            return OkResponse("Convite válido.");
        }

        [HttpGet("grupo/{grupoId}")]
        public async Task<IActionResult> ListarPorGrupo(Guid grupoId)
        {
            var convites = await _listarConvitesUseCase.ExecutarAsync(grupoId);

            return OkResponse(convites);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelarConvite(Guid id)
        {
            await _cancelarConviteUseCase.ExecutarAsync(id);

            return NoContentResponse();
        }
    }
}