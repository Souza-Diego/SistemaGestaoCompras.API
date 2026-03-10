using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Application.DTOs.ListaDeCompras;
using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.Application.UseCases.ListaDeCompras
{
    public class AdicionarItemListaUseCase
    {
        private readonly IListaDeComprasRepositorio _listaRepositorio;

        public AdicionarItemListaUseCase(IListaDeComprasRepositorio listaRepositorio)
        {
            _listaRepositorio = listaRepositorio;
        }

        public async Task<Guid> ExecutarAsync(AdicionarItemListaDto dto)
        {
            var lista = await _listaRepositorio.BuscarPorIdAsync(dto.IdListaDeCompras);

            if (lista == null)
                throw new Exception("Lista de compras não encontrada.");

            var unidade = UnidadeMedida.ObterPorSimbolo(dto.Unidade);

            var item = new ItemLista(
                dto.IdListaDeCompras,
                dto.IdProduto,
                dto.QuantidadePlanejada,
                unidade
            );

            lista.AdicionarItem(item);

            await _listaRepositorio.AtualizarAsync(lista);

            return item.Id;
        }
    }
}