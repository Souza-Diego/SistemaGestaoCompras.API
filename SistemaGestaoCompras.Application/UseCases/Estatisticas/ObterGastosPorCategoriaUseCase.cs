using SistemaGestaoCompras.Application.DTOs.Estatisticas;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.Services;

namespace SistemaGestaoCompras.Application.UseCases.Estatisticas
{
    public class ObterGastosPorCategoriaUseCase
    {
        private readonly ICompraRepositorio _compraRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly EstatisticasCompraService _service;

        public ObterGastosPorCategoriaUseCase(
            ICompraRepositorio compraRepositorio,
            IProdutoRepositorio produtoRepositorio,
            EstatisticasCompraService service)
        {
            _compraRepositorio = compraRepositorio;
            _produtoRepositorio = produtoRepositorio;
            _service = service;
        }

        public async Task<IEnumerable<GastosPorCategoriaDto>> ExecutarAsync(Guid usuarioId)
        {
            var compras = await _compraRepositorio.ObterPorUsuarioAsync(usuarioId);
            var produtos = await _produtoRepositorio.BuscarTodosAsync();

            var resultado = _service.GastosPorCategoria(compras, produtos);

            return resultado.Select(r => new GastosPorCategoriaDto
            {
                IdCategoria = r.Key,
                ValorTotal = r.Value.Valor
            });
        }
    }
}