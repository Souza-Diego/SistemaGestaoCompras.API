using SistemaGestaoCompras.Application.DTOs.Grupos;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Grupos
{
    public class ListarGruposDoUsuarioUseCase
    {
        private readonly IGrupoRepositorio _grupoRepositorio;

        public ListarGruposDoUsuarioUseCase(IGrupoRepositorio grupoRepositorio)
        {
            _grupoRepositorio = grupoRepositorio;
        }

        public async Task<IEnumerable<GrupoDto>> ExecutarAsync(Guid usuarioId)
        {
            var grupos = await _grupoRepositorio.ObterPorUsuarioAsync(usuarioId);

            return grupos.Select(g => new GrupoDto
            {
                Id = g.Id,
                Nome = g.Nome,
                CriadoPor = g.IdCriadoPorUsuario,
                DataCriacao = g.DataCriacao,
                Ativo = g.Ativo
            });
        }
    }
}