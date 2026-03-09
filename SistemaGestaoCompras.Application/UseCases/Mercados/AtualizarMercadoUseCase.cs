using SistemaGestaoCompras.Application.DTOs.Mercados;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Mercados
{
    public class AtualizarMercadoUseCase
    {
        private readonly IMercadoRepositorio _mercadoRepositorio;

        public AtualizarMercadoUseCase(IMercadoRepositorio mercadoRepositorio)
        {
            _mercadoRepositorio = mercadoRepositorio;
        }

        public async Task ExecutarAsync(AtualizarMercadoDto dto)
        {
            var mercado = await _mercadoRepositorio.ObterPorIdAsync(dto.Id);
            if (mercado == null)
                throw new Exception("Mercado não encontrado.");
            mercado.AlterarNome(dto.Nome);
            await _mercadoRepositorio.AtualizarAsync(mercado);
        }
    }
}
