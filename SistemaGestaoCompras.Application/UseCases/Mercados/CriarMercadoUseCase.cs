using SistemaGestaoCompras.Application.DTOs.Mercados;
using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Mercados
{
    public class CriarMercadoUseCase
    {
        private readonly IMercadoRepositorio _mercadoRepositorio;

        public CriarMercadoUseCase(IMercadoRepositorio mercadoRepositorio)
        {
            _mercadoRepositorio = mercadoRepositorio;
        }

        public async Task<Guid> ExecutarAsync(CriarMercadoDto dto)
        {
            var mercado = new Mercado(dto.Nome);
            await _mercadoRepositorio.AdicionarAsync(mercado);
            return mercado.Id;
        }
    }
}
