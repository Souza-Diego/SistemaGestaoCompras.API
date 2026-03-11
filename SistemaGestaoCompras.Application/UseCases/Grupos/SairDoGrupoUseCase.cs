using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Application.DTOs.Grupos;

namespace SistemaGestaoCompras.Application.UseCases.Grupos
{
    public class SairDoGrupoUseCase
    {
        private readonly IGrupoRepositorio _grupoRepositorio;

        public SairDoGrupoUseCase(IGrupoRepositorio grupoRepositorio)
        {
            _grupoRepositorio = grupoRepositorio;
        }

        public async Task ExecutarAsync(SairDoGrupoDto dto)
        {
            var grupo = await _grupoRepositorio.BuscarPorIdAsync(dto.IdGrupo);

            if (grupo == null)
                throw new Exception("Grupo não encontrado.");

            if (!grupo.UsuarioPertenceAoGrupo(dto.IdUsuario))
                throw new Exception("Usuário não pertence ao grupo.");

            grupo.RemoverMembro(dto.IdUsuario);

            await _grupoRepositorio.AtualizarAsync(grupo);
        }
    }
}