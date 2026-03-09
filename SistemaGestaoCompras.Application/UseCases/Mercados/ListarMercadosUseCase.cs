using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Application.DTOs.Mercados;

namespace SistemaGestaoCompras.Application.UseCases.Mercados
{
    public class ListarMercadosUseCase
    {
        private readonly IMercadoRepositorio _mercadoRepositorio;

        public ListarMercadosUseCase(IMercadoRepositorio mercadoRepositorio)
        {
            _mercadoRepositorio = mercadoRepositorio;
        }

        public async Task<IEnumerable<MercadoDto>> ExecutarAsync()
        {
            var mercados = await _mercadoRepositorio.ListarAtivosAsync();
            return mercados.Select(m => new MercadoDto
            {
                Id = m.Id,
                Nome = m.Nome,
                Ativo = m.Ativo
            });
        }
    }
}
