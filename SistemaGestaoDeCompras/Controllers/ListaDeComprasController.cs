using Microsoft.AspNetCore.Mvc;
using SistemaGestaoCompras.Application.DTOs.ListaDeCompras;
using SistemaGestaoCompras.Application.UseCases.ListaDeCompras;
using SistemaGestaoCompras.Application.UseCases.Listas;

namespace SistemaGestaoCompras.API.Controllers
{
    [Route("api/[controller]")]
    public class ListaDeComprasController : BaseController
    {
        private readonly CriarListaDeComprasUseCase _criarListaUseCase;
        private readonly BuscarListaDeComprasPorIdUseCase _buscarListaUseCase;
        private readonly ListarListasDoUsuarioUseCase _listarListasUsuarioUseCase;
        private readonly ListarListasDoGrupoUseCase _listarListasGrupoUseCase;
        private readonly AlterarNomeListaDeComprasUseCase _alterarNomeListaUseCase;
        private readonly DesativarListaDeComprasUseCase _desativarListaUseCase;
        private readonly FinalizarListaDeComprasUseCase _finalizarListaUseCase;
        private readonly ReabrirListaDeComprasUseCase _reabrirListaUseCase;
        private readonly AdicionarItemListaUseCase _adicionarItemUseCase;
        private readonly RemoverItemListaUseCase _removerItemUseCase;
        private readonly AlterarQuantidadeItemListaUseCase _alterarQuantidadeItemUseCase;
        private readonly AlterarUnidadeItemListaUseCase _alterarUnidadeItemUseCase;

        public ListaDeComprasController(
            CriarListaDeComprasUseCase criarListaUseCase,
            BuscarListaDeComprasPorIdUseCase buscarListaUseCase,
            ListarListasDoUsuarioUseCase listarListasUsuarioUseCase,
            ListarListasDoGrupoUseCase listarListasGrupoUseCase,
            AlterarNomeListaDeComprasUseCase alterarNomeListaUseCase,
            DesativarListaDeComprasUseCase desativarListaUseCase,
            FinalizarListaDeComprasUseCase finalizarListaUseCase,
            ReabrirListaDeComprasUseCase reabrirListaUseCase,
            AdicionarItemListaUseCase adicionarItemUseCase,
            RemoverItemListaUseCase removerItemUseCase,
            AlterarQuantidadeItemListaUseCase alterarQuantidadeItemUseCase,
            AlterarUnidadeItemListaUseCase alterarUnidadeItemUseCase)
        {
            _criarListaUseCase = criarListaUseCase;
            _buscarListaUseCase = buscarListaUseCase;
            _listarListasUsuarioUseCase = listarListasUsuarioUseCase;
            _listarListasGrupoUseCase = listarListasGrupoUseCase;
            _alterarNomeListaUseCase = alterarNomeListaUseCase;
            _desativarListaUseCase = desativarListaUseCase;
            _finalizarListaUseCase = finalizarListaUseCase;
            _reabrirListaUseCase = reabrirListaUseCase;
            _adicionarItemUseCase = adicionarItemUseCase;
            _removerItemUseCase = removerItemUseCase;
            _alterarQuantidadeItemUseCase = alterarQuantidadeItemUseCase;
            _alterarUnidadeItemUseCase = alterarUnidadeItemUseCase;
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

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> ListarListasDoUsuario(Guid usuarioId)
        {
            var listas = await _listarListasUsuarioUseCase.ExecutarAsync(usuarioId);
            return OkResponse(listas);
        }

        [HttpGet("grupo/{grupoId}")]
        public async Task<IActionResult> ListarListasDoGrupo(Guid grupoId)
        {
            var listas = await _listarListasGrupoUseCase.ExecutarAsync(grupoId);
            return OkResponse(listas);
        }

        [HttpPut("{id}/nome")]
        public async Task<IActionResult> AlterarNome(Guid id, [FromBody] AlterarNomeListaComprasDto dto)
        {
            dto.Id = id;

            await _alterarNomeListaUseCase.ExecutarAsync(dto);

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

        [HttpPut("{id}/itens/{itemId}/quantidade")]
        public async Task<IActionResult> AlterarQuantidadeItem(
            Guid id,
            Guid itemId,
            [FromBody] AlterarQuantidadeItemListaDto dto)
        {
            dto.IdListaDeCompras = id;
            dto.IdItem = itemId;

            await _alterarQuantidadeItemUseCase.ExecutarAsync(dto);

            return NoContentResponse();
        }

        [HttpPut("{id}/itens/{itemId}/unidade")]
        public async Task<IActionResult> AlterarUnidadeItem(
            Guid id,
            Guid itemId,
            [FromBody] AlterarUnidadeItemListaDto dto)
        {
            dto.IdListaDeCompras = id;
            dto.IdItem = itemId;

            await _alterarUnidadeItemUseCase.ExecutarAsync(dto);

            return NoContentResponse();
        }
    }
}