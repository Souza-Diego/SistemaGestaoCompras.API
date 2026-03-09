using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCase.Usuarios
{
    public class DesativarContaUseCase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public DesativarContaUseCase(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task ExecutarAsync(Guid idUsuario)
        {
            var usuario = await _usuarioRepositorio.ObterPorIdAsync(idUsuario);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            usuario.DesativarConta();
            await _usuarioRepositorio.AtualizarAsync(usuario);
        }
    }
}
