using SistemaGestaoCompras.Application.DTOs.Usuarios;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Usuarios
{
    public class BuscarUsuarioPorEmailUseCase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public BuscarUsuarioPorEmailUseCase(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<UsuarioDto?> ExecutarAsync(string email)
        {
            var usuario = await _usuarioRepositorio.BuscarPorEmailAsync(email);

            if (usuario == null)
                return null;

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