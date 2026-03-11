using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Usuarios
{
    public class ReativarContaUseCase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public ReativarContaUseCase(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task ExecutarAsync(Guid usuarioId)
        {
            var usuario = await _usuarioRepositorio.BuscarPorIdAsync(usuarioId);

            if (usuario == null)
                throw new Exception("Usuário não encontrado");

            usuario.ReativarConta();

            await _usuarioRepositorio.AtualizarAsync(usuario);
        }
    }
}