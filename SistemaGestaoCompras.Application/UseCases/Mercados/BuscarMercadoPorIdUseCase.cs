using SistemaGestaoCompras.Application.DTOs.Mercados;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Mercados
{
    public class BuscarMercadoPorIdUseCase
    {
        private readonly IMercadoRepositorio _mercadoRepositorio;

        public BuscarMercadoPorIdUseCase(IMercadoRepositorio mercadoRepositorio)
        {
            _mercadoRepositorio = mercadoRepositorio;
        }        

        public async Task<MercadoDto?> ExecutarAsync(Guid id)
        {
            var mercado = await _mercadoRepositorio.BuscarPorIdAsync(id);

            if (mercado == null)
                return null;

            return new MercadoDto
            {
                Id = mercado.Id,
                Nome = mercado.Nome,
                Ativo = mercado.Ativo
            };
        }
    }
}