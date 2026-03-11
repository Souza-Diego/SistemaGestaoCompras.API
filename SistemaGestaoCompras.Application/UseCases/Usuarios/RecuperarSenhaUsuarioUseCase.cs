using SistemaGestaoCompras.Application.DTOs.Usuarios;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.Application.UseCases.Usuarios
{
    public class RecuperarSenhaUsuarioUseCase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public RecuperarSenhaUsuarioUseCase(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task ExecutarAsync(RecuperarSenhaUsuarioDto dto)
        {
            var usuario = await _usuarioRepositorio.BuscarPorEmailAsync(dto.Email);

            if (usuario == null)
                throw new Exception("Usuário não encontrado");

            usuario.AlterarSenha(new Senha(dto.NovaSenha));

            await _usuarioRepositorio.AtualizarAsync(usuario);
        }
    }
}
