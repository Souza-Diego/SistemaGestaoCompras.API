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
        private readonly AlterarNomeUsuarioUseCase _alterarNomeUseCase;
        private readonly AlterarEmailUsuarioUseCase _alterarEmailUseCase;
        private readonly AlterarSenhaUsuarioUseCase _alterarSenhaUseCase;
        private readonly AlterarPlanoUsuarioUseCase _alterarPlanoUseCase;
        private readonly DesativarContaUseCase _desativarContaUseCase;
        private readonly ReativarContaUseCase _reativarContaUseCase;
        private readonly BuscarUsuarioPorIdUseCase _buscarUsuarioPorIdUseCase;
        private readonly BuscarUsuarioPorEmailUseCase _buscarUsuarioPorEmailUseCase;
        private readonly ListarUsuariosUseCase _listarUsuariosUseCase;
        private readonly RecuperarSenhaUsuarioUseCase _recuperarSenhaUseCase;

        public UsuarioController(
            CriarUsuarioUseCase criarUsuario,
            LoginUsuarioUseCase loginUsuario,
            AlterarNomeUsuarioUseCase alterarNome,
            AlterarEmailUsuarioUseCase alterarEmail,
            AlterarSenhaUsuarioUseCase alterarSenha,
            AlterarPlanoUsuarioUseCase alterarPlano,
            DesativarContaUseCase desativarConta,
            ReativarContaUseCase reativarConta,
            BuscarUsuarioPorIdUseCase buscarUsuarioPorId,
            BuscarUsuarioPorEmailUseCase buscarUsuarioPorEmail,
            ListarUsuariosUseCase listarUsuarios,
            RecuperarSenhaUsuarioUseCase recuperarSenha)
        {
            _criarUsuarioUseCase = criarUsuario;
            _loginUsuarioUseCase = loginUsuario;
            _alterarNomeUseCase = alterarNome;
            _alterarEmailUseCase = alterarEmail;
            _alterarSenhaUseCase = alterarSenha;
            _alterarPlanoUseCase = alterarPlano;
            _desativarContaUseCase = desativarConta;
            _reativarContaUseCase = reativarConta;
            _buscarUsuarioPorIdUseCase = buscarUsuarioPorId;
            _buscarUsuarioPorEmailUseCase = buscarUsuarioPorEmail;
            _listarUsuariosUseCase = listarUsuarios;
            _recuperarSenhaUseCase = recuperarSenha;
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

        [HttpGet]
        public async Task<IActionResult> ListarUsuarios()
        {
            var usuarios = await _listarUsuariosUseCase.ExecutarAsync();
            return OkResponse(usuarios);
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

        [HttpPut("{id}/nome")]
        public async Task<IActionResult> AlterarNome(Guid id, [FromBody] AlterarNomeUsuarioDto dto)
        {
            dto.Id = id;
            await _alterarNomeUseCase.ExecutarAsync(dto);
            return NoContentResponse();
        }

        [HttpPut("{id}/email")]
        public async Task<IActionResult> AlterarEmail(Guid id, [FromBody] AlterarEmailUsuarioDto dto)
        {
            dto.Id = id;
            await _alterarEmailUseCase.ExecutarAsync(dto);
            return NoContentResponse();
        }

        [HttpPut("{id}/senha")]
        public async Task<IActionResult> AlterarSenha(Guid id, [FromBody] AlterarSenhaUsuarioDto dto)
        {
            dto.Id = id;
            await _alterarSenhaUseCase.ExecutarAsync(dto);
            return NoContentResponse();
        }

        [HttpPut("{id}/plano")]
        public async Task<IActionResult> AlterarPlano(Guid id, [FromBody] AlterarPlanoUsuarioDto dto)
        {
            dto.Id = id;
            await _alterarPlanoUseCase.ExecutarAsync(dto);
            return NoContentResponse();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DesativarConta(Guid id)
        {
            await _desativarContaUseCase.ExecutarAsync(id);
            return NoContentResponse();
        }

        [HttpPut("{id}/reativar")]
        public async Task<IActionResult> ReativarConta(Guid id)
        {
            await _reativarContaUseCase.ExecutarAsync(id);
            return NoContentResponse();
        }

        [HttpPost("recuperar-senha")]
        public async Task<IActionResult> RecuperarSenha([FromBody] RecuperarSenhaUsuarioDto dto)
        {
            await _recuperarSenhaUseCase.ExecutarAsync(dto);
            return NoContentResponse();
        }
    }
}