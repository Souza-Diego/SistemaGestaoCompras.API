using Microsoft.AspNetCore.Mvc;
using SistemaGestaoCompras.Application.UseCase.Convites;
using SistemaGestaoCompras.Application.DTOs.Convites;

namespace SistemaGestaoCompras.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConviteGrupoController : ControllerBase
    {
        private readonly CriarConviteGrupoUseCase _criarConvite;
        private readonly EntrarGrupoPorCodigoUseCase _entrarGrupo;

        public ConviteGrupoController(
            CriarConviteGrupoUseCase criarConvite,
            EntrarGrupoPorCodigoUseCase entrarGrupo)
        {
            _criarConvite = criarConvite;
            _entrarGrupo = entrarGrupo;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarConviteGrupoDto dto)
        {
            var codigo = await _criarConvite.ExecutarAsync(dto);
            return Ok(codigo);
        }

        [HttpPost("entrar")]
        public async Task<IActionResult> Entrar([FromBody] EntrarGrupoPorCodigoDto dto)
        {
            await _entrarGrupo.ExecutarAsync(dto);
            return Ok();
        }
    }
}
