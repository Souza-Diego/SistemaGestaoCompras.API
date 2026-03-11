using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Application.DTOs.ListaDeCompras;

namespace SistemaGestaoCompras.Application.UseCases.ListaDeCompras
{
    public class CriarListaDeComprasAPartirDeTemplateUseCase
    {
        private readonly IListaDeComprasRepositorio _listaRepositorio;
        private readonly IListaDeComprasPadraoRepositorio _templateRepositorio;

        public CriarListaDeComprasAPartirDeTemplateUseCase(
            IListaDeComprasRepositorio listaRepositorio,
            IListaDeComprasPadraoRepositorio templateRepositorio)
        {
            _listaRepositorio = listaRepositorio;
            _templateRepositorio = templateRepositorio;
        }

        public async Task<Guid> ExecutarAsync(CriarListaAPartirDeTemplateDto dto)
        {
            var template = await _templateRepositorio.BuscarPorIdAsync(dto.IdListaPadrao);

            if (template == null)
                throw new Exception("Template não encontrado.");

            ListaDeCompra novaLista;

            if (dto.IdUsuario.HasValue)
                novaLista = new ListaDeCompra(dto.NomeNovaLista, dto.IdUsuario.Value);

            else if (dto.IdGrupo.HasValue)
                novaLista = new ListaDeCompra(dto.NomeNovaLista, dto.IdGrupo.Value, true);

            else
                throw new Exception("A lista precisa pertencer a um usuário ou grupo.");

            foreach (var item in template.Itens)
            {
                var novoItem = new ItemLista(
                    novaLista.Id,
                    item.IdProduto,
                    item.QuantidadePlanejada,
                    item.Unidade
                );

                novaLista.AdicionarItem(novoItem);
            }

            await _listaRepositorio.AdicionarAsync(novaLista);

            return novaLista.Id;
        }
    }
}