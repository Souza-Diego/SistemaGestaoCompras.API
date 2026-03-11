using SistemaGestaoCompras.Application.DTOs.ListaDeCompras;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.Application.UseCases.Listas
{
    public class AlterarUnidadeItemListaUseCase
    {
        private readonly IListaDeComprasRepositorio _listaRepositorio;

        public AlterarUnidadeItemListaUseCase(IListaDeComprasRepositorio listaRepositorio)
        {
            _listaRepositorio = listaRepositorio;
        }

        public async Task ExecutarAsync(AlterarUnidadeItemListaDto dto)
        {
            var lista = await _listaRepositorio.BuscarPorIdAsync(dto.IdListaDeCompras);

            if (lista == null)
                throw new Exception("Lista não encontrada.");

            var item = lista.Itens.FirstOrDefault(i => i.Id == dto.IdItem);

            if (item == null)
                throw new Exception("Item não encontrado.");

            var unidade = UnidadeMedida.ObterPorSimbolo(dto.UnidadeSimbolo);

            item.AlterarUnidade(unidade);

            await _listaRepositorio.AtualizarAsync(lista);
        }
    }
}