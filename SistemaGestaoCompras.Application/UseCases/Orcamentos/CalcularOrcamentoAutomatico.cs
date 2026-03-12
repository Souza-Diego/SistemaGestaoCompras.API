using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.Services;
using SistemaGestaoCompras.Application.DTOs.Orcamentos;

namespace SistemaGestaoCompras.Application.UseCases.Orcamentos
{
    public class CalcularOrcamentoAutomaticoUseCase
    {
        private readonly ICompraRepositorio _compraRepositorio;
        private readonly CalculadoraOrcamentoAutomatico _calculadora;

        public CalcularOrcamentoAutomaticoUseCase(
            ICompraRepositorio compraRepositorio,
            CalculadoraOrcamentoAutomatico calculadora)
        {
            _compraRepositorio = compraRepositorio;
            _calculadora = calculadora;
        }

        public async Task<decimal> ExecutarAsync(Guid usuarioId)
        {
            var compras = await _compraRepositorio.ObterPorUsuarioAsync(usuarioId);

            var media = _calculadora.CalcularMediaMensal(compras);

            return media.Valor;
        }
    }
}
