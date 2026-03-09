using SistemaGestaoCompras.Application.DTOs.Usuarios;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCase.Usuarios
{
    public class LoginUsuarioUseCase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginUsuarioUseCase(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<bool> ExecutarAsync(LoginUsuarioDto dto)
        {
            var usuario = await _usuarioRepositorio.ObterPorEmailAsync(dto.Email);
            if (usuario == null)
                return false;

            return usuario.Senha.VerificarSenha(dto.Senha);
        }
    }
}
