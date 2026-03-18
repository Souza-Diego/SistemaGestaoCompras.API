using SistemaGestaoCompras.Application.DTOs.Usuarios;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.Exceptions;

namespace SistemaGestaoCompras.Application.UseCases.Usuarios
{
    public class AlterarNomeUsuarioUseCase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public AlterarNomeUsuarioUseCase(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task ExecutarAsync(AlterarNomeUsuarioDto dto)
        {
            var usuario = await _usuarioRepositorio.BuscarPorIdAsync(dto.Id);

            if (usuario == null)
                throw new AppDomainException("Esse usuário não foi encontrado. Não deu para atualizar o nome.");

            usuario.AlterarNome(dto.NovoNome);

            await _usuarioRepositorio.AtualizarAsync(usuario);
        }
    }
}