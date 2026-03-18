using SistemaGestaoCompras.Domain.Enums;
using SistemaGestaoCompras.Domain.Exceptions;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

public class AlterarTipoUsuarioUseCase
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;

    public AlterarTipoUsuarioUseCase(IUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }

    public async Task ExecutarAsync(AlterarTipoUsuarioDto dto)
    {
        var usuarioRequisitante = await _usuarioRepositorio.BuscarPorIdAsync(dto.IdUsuarioRequisitante);

        if (usuarioRequisitante == null)
            throw new AppNotFoundException("Não encontramos o requisitante no sistema.");

        if (!usuarioRequisitante.IsADM())
            throw new AppDomainException("Apenas Administradores podem fazer isso.");

        var usuarioAlvo = await _usuarioRepositorio.BuscarPorIdAsync(dto.IdUsuarioAlvo);

        if (usuarioAlvo == null)
            throw new AppNotFoundException("Usuário não encontrado.");
        
        if (usuarioAlvo.IsADM() && dto.NovoTipo != TipoUsuario.Administrador)
        {
            var totalAdmins = await _usuarioRepositorio.ContarAdminsAsync();

            if (totalAdmins <= 1)
                throw new AppDomainException("Não é possível remover o último administrador do sistema.");
        }

        usuarioAlvo.AlterarTipoUsuario(dto.NovoTipo);

        await _usuarioRepositorio.AtualizarAsync(usuarioAlvo);
    }
}