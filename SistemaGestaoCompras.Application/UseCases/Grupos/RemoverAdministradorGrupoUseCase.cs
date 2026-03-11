using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Application.DTOs.Grupos;

namespace SistemaGestaoCompras.Application.UseCases.Grupos
{
    public class RemoverAdministradorGrupoUseCase
    {
        private readonly IGrupoRepositorio _grupoRepositorio;

        public RemoverAdministradorGrupoUseCase(IGrupoRepositorio grupoRepositorio)
        {
            _grupoRepositorio = grupoRepositorio;
        }

        public async Task ExecutarAsync(RemoverAdministradorGrupoDto dto)
        {
            var grupo = await _grupoRepositorio.BuscarPorIdAsync(dto.IdGrupo);

            if (grupo == null)
                throw new Exception("Grupo não encontrado.");

            if (!grupo.UsuarioIsAdministrador(dto.IdUsuarioSolicitante))
                throw new Exception("Somente administradores podem alterar permissões.");

            grupo.RemoverAdministrador(dto.IdUsuario);

            await _grupoRepositorio.AtualizarAsync(grupo);
        }
    }
}