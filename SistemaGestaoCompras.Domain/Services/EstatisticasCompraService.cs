using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.Domain.Services
{
    public class EstatisticasCompraService
    {
        public Dictionary<Guid, Dinheiro> GastosPorCategoria(
            IEnumerable<Compra> compras,
            IEnumerable<Produto> produtos)
        {
            var resultado = new Dictionary<Guid, Dinheiro>();

            foreach (var compra in compras.Where(c => c.Finalizada))
            {
                foreach (var item in compra.Itens)
                {
                    var produto = produtos.FirstOrDefault(p => p.Id == item.Id);

                    if (produto == null)
                        continue;

                    var idCategoria = produto.IdCategoria;
                    var valor = item.CalcularSubTotal();

                    if (!resultado.ContainsKey(idCategoria))
                    {
                        resultado[idCategoria] = valor;
                    }
                    else
                    {
                        resultado[idCategoria] += valor;
                    }
                }
            }

            return resultado;
        }
    }
}