using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Application.DTOs.ListaDeCompras;
using SistemaGestaoCompras.Domain.ValueObjects;
using SistemaGestaoCompras.Domain.Exceptions;

namespace SistemaGestaoCompras.Application.UseCases.ListaDeCompras
{
    public class AdicionarItemListaUseCase
    {
        private readonly IListaDeComprasRepositorio _listaRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IItemListaRepositorio _itemRepositorio;

        public AdicionarItemListaUseCase(
            IListaDeComprasRepositorio listaRepositorio,
            IProdutoRepositorio produtoRepositorio,
            IItemListaRepositorio itemRepositorio)
        {
            _listaRepositorio = listaRepositorio;
            _produtoRepositorio = produtoRepositorio;
            _itemRepositorio = itemRepositorio;
        }

        public async Task<Guid> ExecutarAsync(AdicionarItemListaDto dto)
        {
            var lista = await _listaRepositorio.BuscarPorIdAsync(dto.IdListaDeCompras);

            if (lista == null)
                throw new NotFoundException("Lista de compras", dto.IdListaDeCompras);

            var produto = await _produtoRepositorio.BuscarPorIdAsync(dto.IdProduto);

            if (produto == null)
                throw new NotFoundException("Produto", dto.IdProduto);

            var unidade = UnidadeMedida.ObterPorSimbolo(dto.Unidade);

            var item = new ItemLista(
                dto.IdListaDeCompras,
                dto.IdProduto,
                dto.QuantidadePlanejada,
                unidade
            );

            lista.AdicionarItem(item);

            await _itemRepositorio.AdicionarAsync(item);

            return item.Id;
        }
    }
}