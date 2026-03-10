using SistemaGestaoCompras.Application.DTOs.Grupos;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Grupos
{
    public class AdicionarMembroGrupoUseCase
    {
        private readonly IGrupoRepositorio _grupoRepositorio;

        public AdicionarMembroGrupoUseCase(IGrupoRepositorio grupoRepositorio)
        {
            _grupoRepositorio = grupoRepositorio;
        }

        public async Task ExecutarAsync(AdicionarMembroGrupoDto dto)
        {
            var grupo = await _grupoRepositorio.BuscarPorIdAsync(dto.GrupoId);

            if (grupo == null)
                throw new Exception("Grupo não encontrado");

            if (!grupo.UsuarioIsAdministrador(dto.UsuarioId))
                throw new Exception("Somente administradores podem adicionar membros");

            grupo.AdicionarMembro(dto.UsuarioConvidadoId);

            await _grupoRepositorio.AtualizarAsync(grupo);
        }
    }
}