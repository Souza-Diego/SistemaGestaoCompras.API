using Microsoft.AspNetCore.Mvc;
using SistemaGestaoCompras.Application.UseCases.Grupos;
using SistemaGestaoCompras.Application.DTOs.Grupos;

namespace SistemaGestaoCompras.API.Controllers
{
    [Route("api/[controller]")]
    public class GrupoController : BaseController
    {
        private readonly CriarGrupoUseCase _criarGrupoUseCase;
        private readonly BuscarGrupoPorIdUseCase _buscarGrupoPorIdUseCase;
        private readonly ListarGruposDoUsuarioUseCase _listarGruposDoUsuarioUseCase;
        private readonly AdicionarMembroGrupoUseCase _adicionarMembroGrupoUseCase;
        private readonly RemoverMembroGrupoUseCase _removerMembroGrupoUseCase;
        private readonly SairDoGrupoUseCase _sairDoGrupoUseCase;
        private readonly AlterarNomeGrupoUseCase _alterarNomeGrupoUseCase;
        private readonly DesativarGrupoUseCase _desativarGrupoUseCase;
        private readonly TornarUsuarioAdministradorGrupoUseCase _tornarAdministradorUseCase;
        private readonly RemoverAdministradorGrupoUseCase _removerAdministradorUseCase;

        public GrupoController(
            CriarGrupoUseCase criarGrupo,
            BuscarGrupoPorIdUseCase buscarGrupoPorId,
            ListarGruposDoUsuarioUseCase listarGruposDoUsuario,
            AdicionarMembroGrupoUseCase adicionarMembro,
            RemoverMembroGrupoUseCase removerMembro,
            SairDoGrupoUseCase sairDoGrupo,
            AlterarNomeGrupoUseCase alterarNomeGrupo,
            DesativarGrupoUseCase desativarGrupo,
            TornarUsuarioAdministradorGrupoUseCase tornarAdministrador,
            RemoverAdministradorGrupoUseCase removerAdministrador)
        {
            _criarGrupoUseCase = criarGrupo;
            _buscarGrupoPorIdUseCase = buscarGrupoPorId;
            _listarGruposDoUsuarioUseCase = listarGruposDoUsuario;
            _adicionarMembroGrupoUseCase = adicionarMembro;
            _removerMembroGrupoUseCase = removerMembro;
            _sairDoGrupoUseCase = sairDoGrupo;
            _alterarNomeGrupoUseCase = alterarNomeGrupo;
            _desativarGrupoUseCase = desativarGrupo;
            _tornarAdministradorUseCase = tornarAdministrador;
            _removerAdministradorUseCase = removerAdministrador;
        }

        [HttpPost]
        public async Task<IActionResult> CriarGrupo([FromBody] CriarGrupoDto dto)
        {
            var id = await _criarGrupoUseCase.ExecutarAsync(dto);
            return CreatedResponse(nameof(BuscarGrupoPorId), new { id }, id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarGrupoPorId(Guid id)
        {
            var grupo = await _buscarGrupoPorIdUseCase.ExecutarAsync(id);

            if (grupo == null)
                return NotFoundResponse();

            return OkResponse(grupo);
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> ListarGruposDoUsuario(Guid usuarioId)
        {
            var grupos = await _listarGruposDoUsuarioUseCase.ExecutarAsync(usuarioId);
            return OkResponse(grupos);
        }

        [HttpPost("membros")]
        public async Task<IActionResult> AdicionarMembro([FromBody] AdicionarMembroGrupoDto dto)
        {
            await _adicionarMembroGrupoUseCase.ExecutarAsync(dto);
            return NoContentResponse();
        }

        [HttpDelete("membros")]
        public async Task<IActionResult> RemoverMembro([FromBody] RemoverMembroGrupoDto dto)
        {
            await _removerMembroGrupoUseCase.ExecutarAsync(dto);
            return NoContentResponse();
        }

        [HttpPost("sair")]
        public async Task<IActionResult> SairDoGrupo([FromBody] SairDoGrupoDto dto)
        {
            await _sairDoGrupoUseCase.ExecutarAsync(dto);
            return NoContentResponse();
        }

        [HttpPut("nome")]
        public async Task<IActionResult> AlterarNomeGrupo([FromBody] AlterarNomeGrupoDto dto)
        {
            await _alterarNomeGrupoUseCase.ExecutarAsync(dto);
            return NoContentResponse();
        }

        [HttpPut("administradores")]
        public async Task<IActionResult> TornarAdministrador([FromBody] TornarUsuarioAdministradorGrupoDto dto)
        {
            await _tornarAdministradorUseCase.ExecutarAsync(dto);
            return NoContentResponse();
        }

        [HttpDelete("administradores")]
        public async Task<IActionResult> RemoverAdministrador([FromBody] RemoverAdministradorGrupoDto dto)
        {
            await _removerAdministradorUseCase.ExecutarAsync(dto);
            return NoContentResponse();
        }

        [HttpPut("desativar")]
        public async Task<IActionResult> DesativarGrupo([FromBody] DesativarGrupoDto dto)
        {
            await _desativarGrupoUseCase.ExecutarAsync(dto);
            return NoContentResponse();
        }
    }
}