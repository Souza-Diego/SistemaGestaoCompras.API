using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.Exceptions;

namespace SistemaGestaoCompras.Application.UseCases.Usuarios
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
            var usuario = await _usuarioRepositorio.BuscarPorIdAsync(idUsuario);
            
            if (usuario == null)
                throw new DomainException("Não conseguimos desativar a conta porque esse usuário não foi encontrado.");
            
            usuario.DesativarConta();
            await _usuarioRepositorio.AtualizarAsync(usuario);
        }
    }
}
