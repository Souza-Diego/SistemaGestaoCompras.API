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

        public AdicionarItemListaUseCase(IListaDeComprasRepositorio listaRepositorio)
        {
            _listaRepositorio = listaRepositorio;
        }

        public async Task<Guid> ExecutarAsync(AdicionarItemListaDto dto)
        {
            var lista = await _listaRepositorio.BuscarPorIdAsync(dto.IdListaDeCompras);

            if (lista == null)
                throw new DomainException("Não encontramos essa lista de compras. Talvez ela ainda não tenha sido criada.");

            var unidade = UnidadeMedida.ObterPorSimbolo(dto.Unidade);

            var item = new ItemLista(
                dto.IdListaDeCompras,
                dto.IdProduto,
                dto.QuantidadePlanejada,
                unidade
            );

            lista.AdicionarItem(item);

            await _listaRepositorio.AdicionarAsync(lista);

            return item.Id;
        }
    }
}