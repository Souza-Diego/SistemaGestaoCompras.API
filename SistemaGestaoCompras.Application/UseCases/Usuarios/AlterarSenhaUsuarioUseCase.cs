using SistemaGestaoCompras.Application.DTOs.Usuarios;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.ValueObjects;
using SistemaGestaoCompras.Domain.Exceptions;

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
                throw new AppDomainException("Procuramos em todos os cantos, mas não achamos ninguém com esses dados. Tem certeza que o cadastro foi feito com este login?");

            if (!usuario.Senha.VerificarSenha(dto.SenhaAtual))
                throw new AppDomainException("A senha atual não bateu com a que temos guardada. Pode dar uma conferida se o Caps Lock não está ligado?");

            usuario.AlterarSenha(new Senha(dto.NovaSenha));

            await _usuarioRepositorio.AtualizarAsync(usuario);
        }
    }
}