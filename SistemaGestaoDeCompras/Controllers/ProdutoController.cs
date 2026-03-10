using Microsoft.AspNetCore.Mvc;
using SistemaGestaoCompras.Application.DTOs.Produtos;
using SistemaGestaoCompras.Application.UseCases.Produtos;

namespace SistemaGestaoCompras.API.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController : BaseController
    {
        private readonly CriarProdutoUseCase _criarProduto;
        private readonly ListarProdutosUseCase _listarProdutos;
        private readonly AtualizarProdutoUseCase _atualizarProduto;
        private readonly DesativarProdutoUseCase _desativarProduto;
        private readonly BuscarProdutoPorIdUseCase _buscarProdutoPorId;
        private readonly BuscarProdutosPorCategoriaUseCase _buscarProdutosPorCategoria;
        private readonly BuscarProdutosPorNomeUseCase _buscarProdutosPorNome;

        public ProdutoController(
            CriarProdutoUseCase criarProduto,
            ListarProdutosUseCase listarProdutos,
            AtualizarProdutoUseCase atualizarProduto,
            DesativarProdutoUseCase desativarProduto,
            BuscarProdutoPorIdUseCase buscarProdutoPorId,
            BuscarProdutosPorCategoriaUseCase buscarProdutosPorCategoria,
            BuscarProdutosPorNomeUseCase buscarProdutosPorNome)
        {
            _criarProduto = criarProduto;
            _listarProdutos = listarProdutos;
            _atualizarProduto = atualizarProduto;
            _desativarProduto = desativarProduto;
            _buscarProdutoPorId = buscarProdutoPorId;
            _buscarProdutosPorCategoria = buscarProdutosPorCategoria;
            _buscarProdutosPorNome = buscarProdutosPorNome;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarProdutoDto dto)
        {
            var id = await _criarProduto.ExecutarAsync(dto);
            return CreatedResponse(nameof(BuscarPorId), new { id }, id);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var produtos = await _listarProdutos.ExecutarAsync();
            return OkResponse(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            var produto = await _buscarProdutoPorId.ExecutarAsync(id);

            if (produto == null)
                return NotFoundResponse();

            return OkResponse(produto);
        }

        [HttpGet("categoria/{categoriaId}")]
        public async Task<IActionResult> BuscarPorCategoria(Guid categoriaId)
        {
            var produtos = await _buscarProdutosPorCategoria.ExecutarAsync(categoriaId);
            return OkResponse(produtos);
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarPorNome([FromQuery] string nome)
        {
            var produtos = await _buscarProdutosPorNome.ExecutarAsync(nome);
            return OkResponse(produtos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarProdutoDto dto)
        {
            dto.Id = id;
            await _atualizarProduto.ExecutarAsync(dto);
            return NoContentResponse();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Desativar(Guid id)
        {
            await _desativarProduto.ExecutarAsync(id);
            return NoContentResponse();
        }
    }
}