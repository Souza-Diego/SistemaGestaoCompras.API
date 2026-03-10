using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Application.DTOs.Convites;

namespace SistemaGestaoCompras.Application.UseCases.Convites
{
    public class CriarConviteGrupoUseCase
    {
        private readonly IGrupoRepositorio _grupoRepositorio;
        private readonly IConviteGrupoRepositorio _conviteGrupoRepositorio;

        public CriarConviteGrupoUseCase(
            IGrupoRepositorio grupoRepositorio,
            IConviteGrupoRepositorio conviteGrupoRepositorio)
        {
            _grupoRepositorio = grupoRepositorio;
            _conviteGrupoRepositorio = conviteGrupoRepositorio;
        }

        public async Task<string> ExecutarAsync(CriarConviteGrupoDto dto)
        {
            var grupo = await _grupoRepositorio.BuscarPorIdAsync(dto.IdGrupo);

            if (grupo == null)
            {
                throw new Exception("Grupo não encontrado");
            }

            if (!grupo.UsuarioPertenceAoGrupo(dto.IdUsuarioCriador))
            {
                throw new Exception("Usuário não pertence ao grupo");
            }

            var convite = new ConviteGrupo(
                dto.IdGrupo,
                dto.IdUsuarioCriador,
                dto.DiasValidade);

            await _conviteGrupoRepositorio.AdicionarAsync(convite);
            return convite.Codigo;
        }
    }
}
