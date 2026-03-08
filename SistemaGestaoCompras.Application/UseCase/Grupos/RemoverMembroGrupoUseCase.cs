using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Application.DTOs.Grupos;

namespace SistemaGestaoCompras.Application.UseCase.Grupos
{
    public class RemoverMembroGrupoUseCase
    {
        private readonly IGrupoRepositorio _grupoRepositorio;

        public RemoverMembroGrupoUseCase(IGrupoRepositorio grupoRepositorio)
        {
            _grupoRepositorio = grupoRepositorio;
        }

        public async Task ExecutarAsync(RemoverMembroGrupoDto dto)
        {
            var grupo = await _grupoRepositorio.ObterPorIdAsync(dto.IdGrupo);

            if(grupo == null)
                throw new Exception("Grupo não encontrado.");

            var solicitante = grupo.Membros
                .FirstOrDefault(m => m.IdUsuario == dto.IdUsuarioSolicitante);

            if (solicitante == null)
            {
                throw new Exception("Usuário não pertence ao grupo");
            }

            if (!grupo.UsuarioIsAdministrador(dto.IdUsuarioSolicitante))
            {
                throw new Exception("Apenas administradores podem remover membros do grupo.");
            }

            grupo.RemoverMembro(dto.IdUsuarioRemover);
            await _grupoRepositorio.AtualizarAsync(grupo);
        }
    }
}
