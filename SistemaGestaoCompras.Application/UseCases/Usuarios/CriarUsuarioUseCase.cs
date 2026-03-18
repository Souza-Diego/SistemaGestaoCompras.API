using SistemaGestaoCompras.Application.DTOs.Usuarios;
using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.ValueObjects;
using SistemaGestaoCompras.Domain.Enums;
using SistemaGestaoCompras.Domain.Exceptions;

namespace SistemaGestaoCompras.Application.UseCases.Usuarios
{
    public class CriarUsuarioUseCase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public CriarUsuarioUseCase(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<Guid> ExecutarAsync(CriarUsuarioDto dto)
        {
            var usuarioExistente = await _usuarioRepositorio.BuscarPorEmailAsync(dto.Email);
            if (usuarioExistente != null)
            {
                throw new AppValidationException("Parece que você já passou por aqui! Esse email já tem uma conta. Que tal tentar o login?");
            }

            var email = new Email(dto.Email);
            var senha = new Senha(dto.Senha);
            var usuario = new Usuario(dto.Nome, email, senha, TipoUsuario.Usuario);

            await _usuarioRepositorio.AdicionarAsync(usuario);
            return usuario.Id;
        }
    }
}
