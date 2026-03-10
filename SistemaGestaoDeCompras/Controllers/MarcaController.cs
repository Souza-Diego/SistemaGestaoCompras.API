using Microsoft.AspNetCore.Mvc;
using SistemaGestaoCompras.Application.DTOs.Marcas;
using SistemaGestaoCompras.Application.UseCases.Marcas;

namespace SistemaGestaoCompras.API.Controllers
{

    [Route("api/[controller]")]
    public class MarcaController : BaseController
    {
        private readonly CriarMarcaUseCase _criarMarca;
        private readonly ListarMarcasUseCase _listarMarcas;
        private readonly AtualizarMarcaUseCase _atualizarMarca;
        private readonly DesativarMarcaUseCase _desativarMarca;
        private readonly BuscarMarcaPorIdUseCase _buscarMarcaPorId;

        public MarcaController(
            CriarMarcaUseCase criarMarca,
            ListarMarcasUseCase listarMarcas,
            AtualizarMarcaUseCase atualizarMarca,
            DesativarMarcaUseCase desativarMarca,
            BuscarMarcaPorIdUseCase buscarMarcaPorId)
        {
            _criarMarca = criarMarca;
            _listarMarcas = listarMarcas;
            _atualizarMarca = atualizarMarca;
            _desativarMarca = desativarMarca;
            _buscarMarcaPorId = buscarMarcaPorId;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarMarcaDto dto)
        {
            var id = await _criarMarca.ExecutarAsync(dto);
            return CreatedResponse(nameof(BuscarPorId), new { id }, id);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var marcas = await _listarMarcas.ExecutarAsync();
            return OkResponse(marcas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            var marca = await _buscarMarcaPorId.ExecutarAsync(id);

            if (marca == null)
                return NotFoundResponse();

            return OkResponse(marca);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarMarcaDto dto)
        {
            dto.Id = id;
            await _atualizarMarca.ExecutarAsync(dto);
            return NoContentResponse();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Desativar(Guid id)
        {
            await _desativarMarca.ExecutarAsync(id);
            return NoContentResponse();
        }
    }
}
