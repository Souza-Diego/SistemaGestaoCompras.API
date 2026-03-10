using SistemaGestaoCompras.Application.DTOs.Grupos;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Grupos
{
    public class AlterarNomeGrupoUseCase
    {
        private readonly IGrupoRepositorio _grupoRepositorio;

        public AlterarNomeGrupoUseCase(IGrupoRepositorio grupoRepositorio)
        {
            _grupoRepositorio = grupoRepositorio;
        }

        public async Task ExecutarAsync(AlterarNomeGrupoDto dto)
        {
            var grupo = await _grupoRepositorio.BuscarPorIdAsync(dto.GrupoId);

            if (grupo == null)
                throw new Exception("Grupo não encontrado");

            if (!grupo.UsuarioIsAdministrador(dto.UsuarioId))
                throw new Exception("Somente administradores podem alterar o nome");

            grupo.AlterarNome(dto.NovoNome);

            await _grupoRepositorio.AtualizarAsync(grupo);
        }
    }
}