using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Application.DTOs.ListasPadrao;
using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.Application.UseCases.ListasPadrao
{
    public class AlterarUnidadeItemListaPadraoUseCase
    {
        private readonly IListaDeComprasPadraoRepositorio _repositorio;

        public AlterarUnidadeItemListaPadraoUseCase(IListaDeComprasPadraoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task ExecutarAsync(AlterarUnidadeItemListaPadraoDto dto)
        {
            var lista = await _repositorio.BuscarPorIdAsync(dto.IdListaPadrao);

            if (lista == null)
                throw new Exception("Lista padrão não encontrada.");

            var item = lista.Itens.FirstOrDefault(i => i.IdProduto == dto.IdProduto);

            if (item == null)
                throw new Exception("Item não encontrado na lista.");

            var unidade = UnidadeMedida.ObterPorSimbolo(dto.NovaUnidade);

            item.AlterarUnidade(unidade);

            await _repositorio.AtualizarAsync(lista);
        }
    }
}