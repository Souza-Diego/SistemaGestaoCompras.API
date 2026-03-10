using Microsoft.AspNetCore.Mvc;
using SistemaGestaoCompras.Application.DTOs.Convites;
using SistemaGestaoCompras.Application.UseCases.Convites;

namespace SistemaGestaoCompras.API.Controllers
{
    [Route("api/[controller]")]
    public class ConviteGrupoController : BaseController
    {
        private readonly CriarConviteGrupoUseCase _criarConvite;
        private readonly EntrarGrupoPorCodigoUseCase _entrarGrupo;
        private readonly ListarConvitesGrupoUseCase _listarConvites;
        private readonly CancelarConviteGrupoUseCase _cancelarConvite;

        public ConviteGrupoController(
            CriarConviteGrupoUseCase criarConvite,
            EntrarGrupoPorCodigoUseCase entrarGrupo,
            ListarConvitesGrupoUseCase listarConvites,
            CancelarConviteGrupoUseCase cancelarConvite)
        {
            _criarConvite = criarConvite;
            _entrarGrupo = entrarGrupo;
            _listarConvites = listarConvites;
            _cancelarConvite = cancelarConvite;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarConviteGrupoDto dto)
        {
            var id = await _criarConvite.ExecutarAsync(dto);
            return OkResponse(id);
        }

        [HttpPost("entrar")]
        public async Task<IActionResult> EntrarPorCodigo([FromBody] EntrarGrupoPorCodigoDto dto)
        {
            await _entrarGrupo.ExecutarAsync(dto);
            return NoContentResponse();
        }

        [HttpGet("grupo/{grupoId}")]
        public async Task<IActionResult> ListarPorGrupo(Guid grupoId)
        {
            var convites = await _listarConvites.ExecutarAsync(grupoId);
            return OkResponse(convites);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Cancelar(Guid id)
        {
            await _cancelarConvite.ExecutarAsync(id);
            return NoContentResponse();
        }
    }
}