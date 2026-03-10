using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Application.DTOs.Convites;

namespace SistemaGestaoCompras.Application.UseCases.Convites
{
    public class ListarConvitesGrupoUseCase
    {
        private readonly IConviteGrupoRepositorio _conviteRepositorio;

        public ListarConvitesGrupoUseCase(IConviteGrupoRepositorio conviteRepositorio)
        {
            _conviteRepositorio = conviteRepositorio;
        }

        public async Task<List<ConviteGrupoDto>> ExecutarAsync(Guid grupoId)
        {
            var convites = await _conviteRepositorio.ListarPorGrupoIdAsync(grupoId);

            return convites.Select(c => new ConviteGrupoDto
            {
                Id = c.Id,
                GrupoId = c.IdGrupo,
                Codigo = c.Codigo,
                IdCriadoPorUsuario = c.IdCriadoPorUsuario,
                DataCriacao = c.DataCriacao,
                DataExpiracao = c.DataExpiracao,
                Ativo = c.Ativo
            }).ToList();
        }
    }
}
