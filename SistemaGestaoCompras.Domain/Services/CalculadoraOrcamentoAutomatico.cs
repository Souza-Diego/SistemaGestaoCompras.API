using SistemaGestaoCompras.Domain.ValueObjects;
using SistemaGestaoCompras.Domain.Entities;

namespace SistemaGestaoCompras.Domain.Services
{
    public class CalculadoraOrcamentoAutomatico
    {
        public Dinheiro CalcularMediaMensal(IEnumerable<Compra> compras)
        {
            if(!compras.Any())
                return Dinheiro.Zero;

            var comprasFinalizadas = compras.Where(c => c.Finalizada).ToList();
            var total = comprasFinalizadas.Sum(c => c.CalcularValorTotal().Valor);
            var quantidadeMeses = comprasFinalizadas
                .Select(c => new { c.DataCompra.Year, c.DataCompra.Month })
                .Distinct()
                .Count();

            if(quantidadeMeses == 0)
                return Dinheiro.Zero;

            var media = total / quantidadeMeses;
            return new Dinheiro(media);
        }
    }
}
