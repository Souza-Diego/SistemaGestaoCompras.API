using Microsoft.AspNetCore.Mvc;
using SistemaGestaoCompras.Application.DTOs.ListaDeCompras;
using SistemaGestaoCompras.Application.UseCases.ListaDeCompras;

namespace SistemaGestaoCompras.API.Controllers
{
    [Route("api/[controller]")]
    public class ListaDeComprasController : BaseController
    {
        private readonly CriarListaDeComprasUseCase _criarListaUseCase;
        private readonly BuscarListaDeComprasPorIdUseCase _buscarListaUseCase;
        private readonly ListarListasDeComprasUseCase _listarListasUseCase;
        private readonly AtualizarListaDeComprasUseCase _atualizarListaUseCase;
        private readonly DesativarListaDeComprasUseCase _desativarListaUseCase;
        private readonly FinalizarListaDeComprasUseCase _finalizarListaUseCase;
        private readonly ReabrirListaDeComprasUseCase _reabrirListaUseCase;
        private readonly AdicionarItemListaUseCase _adicionarItemUseCase;
        private readonly RemoverItemListaUseCase _removerItemUseCase;

        public ListaDeComprasController(
            CriarListaDeComprasUseCase criarListaUseCase,
            BuscarListaDeComprasPorIdUseCase buscarListaUseCase,
            ListarListasDeComprasUseCase listarListasUseCase,
            AtualizarListaDeComprasUseCase atualizarListaUseCase,
            DesativarListaDeComprasUseCase desativarListaUseCase,
            FinalizarListaDeComprasUseCase finalizarListaUseCase,
            ReabrirListaDeComprasUseCase reabrirListaUseCase,
            AdicionarItemListaUseCase adicionarItemUseCase,
            RemoverItemListaUseCase removerItemUseCase)
        {
            _criarListaUseCase = criarListaUseCase;
            _buscarListaUseCase = buscarListaUseCase;
            _listarListasUseCase = listarListasUseCase;
            _atualizarListaUseCase = atualizarListaUseCase;
            _desativarListaUseCase = desativarListaUseCase;
            _finalizarListaUseCase = finalizarListaUseCase;
            _reabrirListaUseCase = reabrirListaUseCase;
            _adicionarItemUseCase = adicionarItemUseCase;
            _removerItemUseCase = removerItemUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CriarLista([FromBody] CriarListaComprasDto dto)
        {
            var id = await _criarListaUseCase.ExecutarAsync(dto);
            return CreatedResponse(nameof(BuscarListaPorId), new { id }, new { id });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarListaPorId(Guid id)
        {
            var lista = await _buscarListaUseCase.ExecutarAsync(id);

            if (lista == null)
                return NotFoundResponse();

            return OkResponse(lista);
        }

        [HttpGet]
        public async Task<IActionResult> ListarListas()
        {
            var listas = await _listarListasUseCase.ExecutarAsync();
            return OkResponse(listas);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarLista(Guid id, [FromBody] AtualizarListaComprasDto dto)
        {
            dto.Id = id;
            await _atualizarListaUseCase.ExecutarAsync(dto);
            return NoContentResponse();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DesativarLista(Guid id)
        {
            await _desativarListaUseCase.ExecutarAsync(id);
            return NoContentResponse();
        }

        [HttpPost("{id}/finalizar")]
        public async Task<IActionResult> FinalizarLista(Guid id)
        {
            await _finalizarListaUseCase.ExecutarAsync(id);
            return NoContentResponse();
        }

        [HttpPost("{id}/reabrir")]
        public async Task<IActionResult> ReabrirLista(Guid id)
        {
            await _reabrirListaUseCase.ExecutarAsync(id);
            return NoContentResponse();
        }

        [HttpPost("{id}/itens")]
        public async Task<IActionResult> AdicionarItem(Guid id, [FromBody] AdicionarItemListaDto dto)
        {
            dto.IdListaDeCompras = id;

            var itemId = await _adicionarItemUseCase.ExecutarAsync(dto);

            return OkResponse(new { id = itemId });
        }

        [HttpDelete("{id}/itens/{itemId}")]
        public async Task<IActionResult> RemoverItem(Guid id, Guid itemId)
        {
            var dto = new RemoverItemListaDto
            {
                IdListaDeCompras = id,
                IdItem = itemId
            };

            await _removerItemUseCase.ExecutarAsync(dto);

            return NoContentResponse();
        }
    }
}