using SistemaGestaoCompras.Application.DTOs.Convites;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Convites
{
    public class ValidarConviteGrupoUseCase
    {
        private readonly IConviteGrupoRepositorio _conviteRepositorio;

        public ValidarConviteGrupoUseCase(IConviteGrupoRepositorio conviteRepositorio)
        {
            _conviteRepositorio = conviteRepositorio;
        }

        public async Task<bool> ExecutarAsync(ValidarConviteGrupoDto dto)
        {
            var convite = await _conviteRepositorio.BuscarPorCodigoAsync(dto.Codigo);

            if (convite == null)
                return false;

            return convite.EstaValido();
        }
    }
}