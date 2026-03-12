using SistemaGestaoCompras.Application.DTOs.Listas;
using SistemaGestaoCompras.Domain.Exceptions;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Listas
{
    public class CalcularCustoListaUseCase
    {
        private readonly IListaDeComprasRepositorio _listaRepositorio;
        private readonly IRegistroDePrecoRepositorio _precoRepositorio;

        public CalcularCustoListaUseCase(
            IListaDeComprasRepositorio listaRepositorio,
            IRegistroDePrecoRepositorio precoRepositorio)
        {
            _listaRepositorio = listaRepositorio;
            _precoRepositorio = precoRepositorio;
        }

        public async Task<CustoListaDto> ExecutarAsync(Guid listaId)
        {
            var lista = await _listaRepositorio.BuscarPorIdAsync(listaId);

            if (lista == null)
                throw new NotFoundException("Lista não encontrada.");

            decimal total = 0;

            foreach (var item in lista.Itens)
            {
                var precos = await _precoRepositorio.ObterPorProdutoAsync(item.IdProduto);

                var menorPreco = precos
                    .OrderBy(p => p.Preco.Valor)
                    .FirstOrDefault();

                if (menorPreco != null)
                {
                    total += menorPreco.Preco.Valor * item.QuantidadePlanejada;
                }
            }

            return new CustoListaDto
            {
                ListaId = listaId,
                CustoTotal = total
            };
        }
    }
}