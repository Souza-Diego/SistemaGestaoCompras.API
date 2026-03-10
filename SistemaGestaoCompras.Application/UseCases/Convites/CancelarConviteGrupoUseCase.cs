using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Convites
{
    public class CancelarConviteGrupoUseCase
    {
        private readonly IConviteGrupoRepositorio _conviteRepositorio;

        public CancelarConviteGrupoUseCase(IConviteGrupoRepositorio conviteRepositorio)
        {
            _conviteRepositorio = conviteRepositorio;
        }

        public async Task ExecutarAsync(Guid conviteId)
        {
            var convite = await _conviteRepositorio.BuscarPorIdAsync(conviteId);

            if (convite == null)
                throw new Exception("Convite não encontrado.");

            if (!convite.Ativo)
                throw new Exception("O convite já está cancelado ou expirado.");

            convite.Desativar();

            await _conviteRepositorio.AtualizarAsync(convite);
        }
    }
}