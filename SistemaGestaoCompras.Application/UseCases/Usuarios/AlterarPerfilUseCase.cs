using SistemaGestaoCompras.Application.DTOs.Usuarios;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.Application.UseCases.Usuarios
{
    public class AlterarPerfilUseCase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public AlterarPerfilUseCase(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task ExecutarAsync(AlterarPerfilDto dto)
        {
            var usuario = await _usuarioRepositorio.ObterPorIdAsync(dto.Id);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            usuario.AlterarNome(dto.NovoNome);
            usuario.AlterarEmail(new Email(dto.NovoEmail));
            await _usuarioRepositorio.AtualizarAsync(usuario);
        }
    }
}
