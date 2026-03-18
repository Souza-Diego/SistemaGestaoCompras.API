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
                throw new AppDomainException("Não encontramos esse usuário para atualizar o email.");

            var novoEmail = new Email(dto.NovoEmail);
            if (usuario.Email.Endereco == novoEmail.Endereco)
                return;

            var emailJaExiste = await _usuarioRepositorio
                .ExistePorEmailAsync(novoEmail.Endereco, usuario.Id);
            if (emailJaExiste)
                throw new AppDomainException("Este e-mail já está sendo usado no sistema.");

            usuario.AlterarEmail(novoEmail);

            await _usuarioRepositorio.AtualizarAsync(usuario);
        }
    }
}