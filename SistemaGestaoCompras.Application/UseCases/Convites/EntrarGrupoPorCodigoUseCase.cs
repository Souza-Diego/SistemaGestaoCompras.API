using SistemaGestaoCompras.Application.DTOs.Convites;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Convites
{
    public class EntrarGrupoPorCodigoUseCase
    {
        private readonly IConviteGrupoRepositorio _conviteGrupoRepositorio;
        private readonly IGrupoRepositorio _grupoRepositorio;

        public EntrarGrupoPorCodigoUseCase(
            IConviteGrupoRepositorio conviteGrupoRepositorio,
            IGrupoRepositorio grupoRepositorio)
        {
            _conviteGrupoRepositorio = conviteGrupoRepositorio;
            _grupoRepositorio = grupoRepositorio;
        }

        public async Task ExecutarAsync(EntrarGrupoPorCodigoDto dto)
        {
            var convite = await _conviteGrupoRepositorio.BuscarPorCodigoAsync(dto.Codigo);

            if (convite == null)
                throw new Exception("Convite não encontrado.");

            if (!convite.EstaValido())
                throw new Exception("Convite expirado ou inválido.");

            var grupo = await _grupoRepositorio.BuscarPorIdAsync(convite.IdGrupo);

            if (grupo == null)
                throw new Exception("Grupo não encontrado.");

            if (grupo.UsuarioPertenceAoGrupo(dto.IdUsuario))
                throw new Exception("Usuário já pertence ao grupo.");

            grupo.AdicionarMembro(dto.IdUsuario);
            await _grupoRepositorio.AtualizarAsync(grupo);
        }
    }
}
