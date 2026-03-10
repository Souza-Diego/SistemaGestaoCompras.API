using Microsoft.AspNetCore.Mvc;
using SistemaGestaoCompras.Application.UseCases.Usuarios;
using SistemaGestaoCompras.Application.DTOs.Usuarios;

namespace SistemaGestaoCompras.API.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : BaseController
    {
        private readonly CriarUsuarioUseCase _criarUsuarioUseCase;
        private readonly LoginUsuarioUseCase _loginUsuarioUseCase;
        private readonly AlterarPerfilUseCase _alterarPerfilUseCase;
        private readonly DesativarContaUseCase _desativarContaUseCase;
        private readonly BuscarUsuarioPorIdUseCase _buscarUsuarioPorIdUseCase;
        private readonly BuscarUsuarioPorEmailUseCase _buscarUsuarioPorEmailUseCase;

        public UsuarioController(
            CriarUsuarioUseCase criarUsuario,
            LoginUsuarioUseCase loginUsuario,
            AlterarPerfilUseCase alterarPerfil,
            DesativarContaUseCase desativarConta,
            BuscarUsuarioPorIdUseCase buscarUsuarioPorId,
            BuscarUsuarioPorEmailUseCase buscarUsuarioPorEmail)
        {
            _criarUsuarioUseCase = criarUsuario;
            _loginUsuarioUseCase = loginUsuario;
            _alterarPerfilUseCase = alterarPerfil;
            _desativarContaUseCase = desativarConta;
            _buscarUsuarioPorIdUseCase = buscarUsuarioPorId;
            _buscarUsuarioPorEmailUseCase = buscarUsuarioPorEmail;
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] CriarUsuarioDto dto)
        {
            var id = await _criarUsuarioUseCase.ExecutarAsync(dto);
            return CreatedResponse(nameof(BuscarPorId), new { id }, id);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUsuarioDto dto)
        {
            var sucesso = await _loginUsuarioUseCase.ExecutarAsync(dto);

            if (!sucesso)
                return Unauthorized();

            return OkResponse("Login realizado com sucesso.");
        }

        [HttpPut]
        public async Task<IActionResult> AlterarPerfil([FromBody] AlterarPerfilDto dto)
        {
            await _alterarPerfilUseCase.ExecutarAsync(dto);
            return NoContentResponse();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DesativarConta(Guid id)
        {
            await _desativarContaUseCase.ExecutarAsync(id);
            return NoContentResponse();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            var usuario = await _buscarUsuarioPorIdUseCase.ExecutarAsync(id);

            if (usuario == null)
                return NotFoundResponse();

            return OkResponse(usuario);
        }

        [HttpGet("email")]
        public async Task<IActionResult> BuscarPorEmail([FromQuery] string email)
        {
            var usuario = await _buscarUsuarioPorEmailUseCase.ExecutarAsync(email);

            if (usuario == null)
                return NotFoundResponse();

            return OkResponse(usuario);
        }
    }
}