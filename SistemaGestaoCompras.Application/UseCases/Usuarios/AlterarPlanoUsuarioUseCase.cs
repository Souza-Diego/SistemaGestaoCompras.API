using SistemaGestaoCompras.Application.DTOs.Usuarios;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.Exceptions;

namespace SistemaGestaoCompras.Application.UseCases.Usuarios
{
    public class AlterarPlanoUsuarioUseCase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public AlterarPlanoUsuarioUseCase(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task ExecutarAsync(AlterarPlanoUsuarioDto dto)
        {
            var usuario = await _usuarioRepositorio.BuscarPorIdAsync(dto.Id);

            if (usuario == null)
                throw new DomainException("Não conseguimos encontrar esse usuário para alterar o plano");

            usuario.AlterarPlano(dto.NovoPlano);

            await _usuarioRepositorio.AtualizarAsync(usuario);
        }
    }
}