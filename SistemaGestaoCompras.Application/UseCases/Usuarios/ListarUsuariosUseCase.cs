using SistemaGestaoCompras.Application.DTOs.Usuarios;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Usuarios
{
    public class ListarUsuariosUseCase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public ListarUsuariosUseCase(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<IEnumerable<UsuarioDto>> ExecutarAsync()
        {
            var usuarios = await _usuarioRepositorio.BuscarTodosAsync();

            return usuarios.Select(u => new UsuarioDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email.Endereco,
                Plano = u.Plano.ToString(),
                TipoUsuario = u.TipoUsuario.ToString(),
                Ativo = u.Ativo,
                DataCriacao = u.DataCriacao
            });
        }
    }
}