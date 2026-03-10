using SistemaGestaoCompras.Application.DTOs.Grupos;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

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
            var grupo = await _grupoRepositorio.BuscarPorIdAsync(dto.GrupoId);

            if (grupo == null)
                throw new Exception("Grupo não encontrado");

            grupo.RemoverMembro(dto.UsuarioId);

            await _grupoRepositorio.AtualizarAsync(grupo);
        }
    }
}