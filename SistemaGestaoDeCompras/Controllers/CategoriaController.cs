using Microsoft.AspNetCore.Mvc;
using SistemaGestaoCompras.Application.DTOs.Categorias;
using SistemaGestaoCompras.Application.UseCases.Categorias;

namespace SistemaGestaoCompras.API.Controllers
{
    
    [Route("api/[controller]")]
    public class CategoriaController : BaseController
    {
        private readonly CriarCategoriaUseCase _criarCategoria;
        private readonly ListarCategoriasUseCase _listarCategorias;
        private readonly AtualizarCategoriaUseCase _atualizarCategoria;
        private readonly DesativarCategoriaUseCase _desativarCategoria;
        private readonly BuscarCategoriaPorIdUseCase _buscarCategoriaPorId;

        public CategoriaController(
            CriarCategoriaUseCase criarCategoria,
            ListarCategoriasUseCase listarCategorias,
            AtualizarCategoriaUseCase atualizarCategoria,
            DesativarCategoriaUseCase desativarCategoria,
            BuscarCategoriaPorIdUseCase buscarCategoriaPorId)
        {
            _criarCategoria = criarCategoria;
            _listarCategorias = listarCategorias;
            _atualizarCategoria = atualizarCategoria;
            _desativarCategoria = desativarCategoria;
            _buscarCategoriaPorId = buscarCategoriaPorId;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarCategoriaDto dto)
        {
            var id = await _criarCategoria.ExecutarAsync(dto);
            return CreatedResponse(nameof(BuscarPorId), new {id}, id);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var categorias = await _listarCategorias.ExecutarAsync();
            return OkResponse(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            var categoria = await _buscarCategoriaPorId.ExecutarAsync(id);

            if (categoria == null)
                return NotFoundResponse();

            return OkResponse(categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarCategoriaDto dto)
        {
            dto.Id = id;
            await _atualizarCategoria.ExecutarAsync(dto);
            return NoContentResponse();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Desativar(Guid id)
        {
            await _desativarCategoria.ExecutarAsync(id);
            return NoContentResponse();
        }
    }
}
