using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Application.DTOs.Grupos;
using SistemaGestaoCompras.Domain.Entities;

namespace SistemaGestaoCompras.Application.UseCase.Grupos
{
    public class CriarGrupoUseCase
    {
        private readonly IGrupoRepositorio _grupoRepositorio;
        public CriarGrupoUseCase(IGrupoRepositorio grupoRepositorio)
        {
            _grupoRepositorio = grupoRepositorio;
        }
        public async Task<Guid> ExecutarAsync(CriarGrupoDto dto)
        {
            var grupo = new Grupo(dto.Nome, dto.IdUsuarioCriador);
            await _grupoRepositorio.AdicionarAsync(grupo);
            return grupo.Id;
        }
    }
}
