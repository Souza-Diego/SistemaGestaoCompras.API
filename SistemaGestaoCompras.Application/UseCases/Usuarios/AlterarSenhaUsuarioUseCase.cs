using SistemaGestaoCompras.Application.DTOs.Usuarios;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.Application.UseCases.Usuarios
{
    public class AlterarSenhaUsuarioUseCase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public AlterarSenhaUsuarioUseCase(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task ExecutarAsync(AlterarSenhaUsuarioDto dto)
        {
            var usuario = await _usuarioRepositorio.BuscarPorIdAsync(dto.Id);

            if (usuario == null)
                throw new Exception("Usuário não encontrado");

            if (!usuario.Senha.VerificarSenha(dto.SenhaAtual))
                throw new Exception("Senha atual inválida");

            usuario.AlterarSenha(new Senha(dto.NovaSenha));

            await _usuarioRepositorio.AtualizarAsync(usuario);
        }
    }
}