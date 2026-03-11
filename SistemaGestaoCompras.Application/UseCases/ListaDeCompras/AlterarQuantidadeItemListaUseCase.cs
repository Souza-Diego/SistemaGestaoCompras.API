using SistemaGestaoCompras.Application.DTOs.ListaDeCompras;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Listas
{
    public class AlterarQuantidadeItemListaUseCase
    {
        private readonly IListaDeComprasRepositorio _listaRepositorio;

        public AlterarQuantidadeItemListaUseCase(IListaDeComprasRepositorio listaRepositorio)
        {
            _listaRepositorio = listaRepositorio;
        }

        public async Task ExecutarAsync(AlterarQuantidadeItemListaDto dto)
        {
            var lista = await _listaRepositorio.BuscarPorIdAsync(dto.ListaId);

            if (lista == null)
                throw new Exception("Lista não encontrada.");

            var item = lista.Itens.FirstOrDefault(i => i.Id == dto.ItemId);

            if (item == null)
                throw new Exception("Item não encontrado.");

            item.AlterarQuantidadePlanejada(dto.NovaQuantidade);

            await _listaRepositorio.AtualizarAsync(lista);
        }
    }
}