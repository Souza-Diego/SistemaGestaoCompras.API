using SistemaGestaoCompras.Application.DTOs.RegistroDePrecos;
using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.RegistroDePrecos
{
    public class ListarPrecosPorMercadoUseCase
    {
        private readonly IRegistroDePrecoRepositorio _repositorio;

        public ListarPrecosPorMercadoUseCase(IRegistroDePrecoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<RegistroDePreco>> ExecutarAsync(ListarPrecosPorMercadoDto dto)
        {
            var registros = await _repositorio.BuscarTodosAsync();

            return registros.Where(r => r.IdMercado == dto.IdMercado);
        }
    }
}