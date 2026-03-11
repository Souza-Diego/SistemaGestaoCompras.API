using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Application.DTOs.Grupos;

namespace SistemaGestaoCompras.Application.UseCases.Grupos
{
    public class DesativarGrupoUseCase
    {
        private readonly IGrupoRepositorio _grupoRepositorio;

        public DesativarGrupoUseCase(IGrupoRepositorio grupoRepositorio)
        {
            _grupoRepositorio = grupoRepositorio;
        }

        public async Task ExecutarAsync(DesativarGrupoDto dto)
        {
            var grupo = await _grupoRepositorio.BuscarPorIdAsync(dto.IdGrupo);

            if (grupo == null)
                throw new Exception("Grupo não encontrado.");

            if (!grupo.UsuarioIsAdministrador(dto.IdUsuarioSolicitante))
                throw new Exception("Somente administradores podem desativar o grupo.");

            grupo.Desativar();

            await _grupoRepositorio.AtualizarAsync(grupo);
        }
    }
}