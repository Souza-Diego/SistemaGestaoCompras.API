using Microsoft.AspNetCore.Mvc;
using SistemaGestaoCompras.Application.DTOs.Marcas;
using SistemaGestaoCompras.Application.DTOs.Mercados;
using SistemaGestaoCompras.Application.UseCases.Mercados;

namespace SistemaGestaoCompras.API.Controllers
{
    [Route("api/[controller]")]
    public class MercadoController : BaseController
    {
        private readonly CriarMercadoUseCase _criarMercado;
        private readonly ListarMercadosUseCase _listarMercados;
        private readonly AtualizarMercadoUseCase _atualizarMercado;
        private readonly DesativarMercadoUseCase _desativarMercado;
        private readonly BuscarMercadoPorIdUseCase _buscarMercadoPorId;

        public MercadoController(
            CriarMercadoUseCase criarMercado,
            ListarMercadosUseCase listarMercados,
            AtualizarMercadoUseCase atualizarMercado,
            DesativarMercadoUseCase desativarMarcado,
            BuscarMercadoPorIdUseCase buscarMercadoPorId)
        {
            _criarMercado = criarMercado;
            _listarMercados = listarMercados;
            _atualizarMercado = atualizarMercado;
            _desativarMercado = desativarMarcado;
            _buscarMercadoPorId = buscarMercadoPorId;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarMercadoDto dto)
        {
            var id = await _criarMercado.ExecutarAsync(dto);
            return CreatedResponse(nameof(BuscarPorId), new { id }, id);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var mercados = await _listarMercados.ExecutarAsync();
            return OkResponse(mercados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            var mercado = await _buscarMercadoPorId.ExecutarAsync(id);

            if (mercado == null)
                return NotFoundResponse();

            return OkResponse(mercado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarMercadoDto dto)
        {
            dto.Id = id;
            await _atualizarMercado.ExecutarAsync(dto);
            return NoContentResponse();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Desativar(Guid id)
        {
            await _desativarMercado.ExecutarAsync(id);
            return NoContentResponse();
        }
    }
}
