using SistemaGestaoCompras.Application.DTOs.Grupos;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Grupos
{
    public class BuscarGrupoPorIdUseCase
    {
        private readonly IGrupoRepositorio _grupoRepositorio;

        public BuscarGrupoPorIdUseCase(IGrupoRepositorio grupoRepositorio)
        {
            _grupoRepositorio = grupoRepositorio;
        }

        public async Task<GrupoDto?> ExecutarAsync(Guid grupoId)
        {
            var grupo = await _grupoRepositorio.BuscarPorIdAsync(grupoId);

            if (grupo == null)
                return null;

            return new GrupoDto
            {
                Id = grupo.Id,
                Nome = grupo.Nome,
                CriadoPor = grupo.IdCriadoPorUsuario,
                DataCriacao = grupo.DataCriacao,
                Ativo = grupo.Ativo
            };
        }
    }
}