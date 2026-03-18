using SistemaGestaoCompras.Application.DTOs.Usuarios;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.Exceptions;

namespace SistemaGestaoCompras.Application.UseCases.Usuarios
{
    public class LoginUsuarioUseCase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginUsuarioUseCase(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task ExecutarAsync(LoginUsuarioDto dto)
        {
            var usuario = await _usuarioRepositorio.BuscarPorEmailAsync(dto.Email);

            if (usuario == null)
                throw new AppDomainException("Ops! Algo na sua dupla de acesso não bateu. Pode dar uma olhadinha no que foi digitado?.");

            if (!usuario.Ativo)
                throw new AppDomainException("Esta conta está desativada.");

            if (!usuario.Senha.VerificarSenha(dto.Senha))
                throw new AppDomainException("Ops! Algo na sua dupla de acesso não bateu. Pode dar uma olhadinha no que foi digitado?.");
        }
    }
}
