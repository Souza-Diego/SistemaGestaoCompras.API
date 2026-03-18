using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.Exceptions;
using SistemaGestaoCompras.Application.DTOs.ListaDeCompras;

namespace SistemaGestaoCompras.Application.UseCases.ListaDeCompras
{
    public class ListarItensDaListaUseCase
    {
        private readonly IListaDeComprasRepositorio _listaRepositorio;

        public ListarItensDaListaUseCase(IListaDeComprasRepositorio listaRepositorio)
        {
            _listaRepositorio = listaRepositorio;
        }

        public async Task<IEnumerable<ItemListaDetalhadoDto>> ExecutarAsync(Guid idLista)
        {
            var lista = await _listaRepositorio.BuscarPorIdAsync(idLista);

            if (lista == null)
                throw new AppNotFoundException("Lista de compras", idLista);

            return lista.Itens.Select(i => new ItemListaDetalhadoDto
            {
                IdProduto = i.IdProduto,
                Quantidade = i.QuantidadePlanejada,
                Unidade = i.Unidade.Simbolo
            });
        }
    }
}
