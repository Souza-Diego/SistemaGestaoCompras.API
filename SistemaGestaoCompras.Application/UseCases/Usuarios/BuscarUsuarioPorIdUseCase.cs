using SistemaGestaoCompras.Application.DTOs.Usuarios;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.Exceptions;

namespace SistemaGestaoCompras.Application.UseCases.Usuarios
{
    public class BuscarUsuarioPorIdUseCase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public BuscarUsuarioPorIdUseCase(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<UsuarioDto?> ExecutarAsync(Guid id)
        {
            var usuario = await _usuarioRepositorio.BuscarPorIdAsync(id);

            if (usuario == null)
                throw new DomainException("Hmm... procuramos por esse usuário, mas ele parece não existir por aqui.");

            return new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email.Endereco,
                Plano = usuario.Plano.ToString(),
                TipoUsuario = usuario.TipoUsuario.ToString(),
                Ativo = usuario.Ativo,
                DataCriacao = usuario.DataCriacao
            };
        }
    }
}