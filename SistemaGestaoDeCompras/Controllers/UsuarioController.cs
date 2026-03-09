using Microsoft.AspNetCore.Mvc;
using SistemaGestaoCompras.Application.UseCases.Usuarios;
using SistemaGestaoCompras.Application.DTOs.Usuarios;

namespace SistemaGestaoCompras.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly CriarUsuarioUseCase _criarUsuarioUseCase;
        private readonly LoginUsuarioUseCase _loginUsuarioUseCase;
        private readonly AlterarPerfilUseCase _alterarPerfilUseCase;
        private readonly DesativarContaUseCase _desativarContaUseCase;

        public UsuarioController(
            CriarUsuarioUseCase criarUsuario,
            LoginUsuarioUseCase loginUsuario,
            AlterarPerfilUseCase alterarPerfil,
            DesativarContaUseCase desativarConta)
        {
            _criarUsuarioUseCase = criarUsuario;
            _loginUsuarioUseCase = loginUsuario;
            _alterarPerfilUseCase = alterarPerfil;
            _desativarContaUseCase = desativarConta;
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] CriarUsuarioDto dto)
        {
            var id = await _criarUsuarioUseCase.ExecutarAsync(dto);
            return Ok(id);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUsuarioDto dto)
        {
            var sucesso = await _loginUsuarioUseCase.ExecutarAsync(dto);

            if (!sucesso)
                return Unauthorized();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> AlterarPerfil([FromBody] AlterarPerfilDto dto)
        {
            await _alterarPerfilUseCase.ExecutarAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DesativarConta(Guid id)
        {
            await _desativarContaUseCase.ExecutarAsync(id);
            return Ok();
        }
    }
}
