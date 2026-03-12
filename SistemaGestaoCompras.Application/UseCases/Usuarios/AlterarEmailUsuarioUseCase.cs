using SistemaGestaoCompras.Application.DTOs.Usuarios;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.ValueObjects;
using SistemaGestaoCompras.Domain.Exceptions;

namespace SistemaGestaoCompras.Application.UseCases.Usuarios
{
    public class AlterarEmailUsuarioUseCase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public AlterarEmailUsuarioUseCase(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task ExecutarAsync(AlterarEmailUsuarioDto dto)
        {
            var usuario = await _usuarioRepositorio.BuscarPorIdAsync(dto.Id);

            if (usuario == null)
                throw new DomainException("Não encontramos esse usuário para atualizar o email.");

            usuario.AlterarEmail(new Email(dto.NovoEmail));

            await _usuarioRepositorio.AtualizarAsync(usuario);
        }
    }
}