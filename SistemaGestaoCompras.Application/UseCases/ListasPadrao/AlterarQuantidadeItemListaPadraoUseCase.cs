using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Application.DTOs.ListasPadrao;

namespace SistemaGestaoCompras.Application.UseCases.ListasPadrao
{
    public class AlterarQuantidadeItemListaPadraoUseCase
    {
        private readonly IListaDeComprasPadraoRepositorio _repositorio;

        public AlterarQuantidadeItemListaPadraoUseCase(IListaDeComprasPadraoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task ExecutarAsync(AlterarQuantidadeItemListaPadraoDto dto)
        {
            var lista = await _repositorio.BuscarPorIdAsync(dto.IdListaPadrao);

            if (lista == null)
                throw new Exception("Lista padrão não encontrada.");

            var item = lista.Itens.FirstOrDefault(i => i.IdProduto == dto.IdProduto);

            if (item == null)
                throw new Exception("Item não encontrado na lista.");

            item.AlterarQuantidade(dto.NovaQuantidade);

            await _repositorio.AtualizarAsync(lista);
        }
    }
}