using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.Exceptions;

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
                throw new DomainException("Tentamos reativar a conta, mas não encontramos esse usuário no sistema.");

            usuario.Ativar();

            await _usuarioRepositorio.AtualizarAsync(usuario);
        }
    }
}