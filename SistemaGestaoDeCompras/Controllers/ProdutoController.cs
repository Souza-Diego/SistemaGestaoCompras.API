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
        private readonly ObterProdutoPorIdUseCase _obterProdutoPorId;
        private readonly ListarProdutosPorCategoriaUseCase _listarProdutosPorCategoria;
        private readonly BuscarProdutoPorNomeUseCase _buscarProdutoPorNome;
        private readonly AlterarNomeProdutoUseCase _alterarNomeProduto;
        private readonly AlterarCategoriaProdutoUseCase _alterarCategoriaProduto;
        private readonly AlterarMarcaProdutoUseCase _alterarMarcaProduto;
        private readonly DesativarProdutoUseCase _desativarProduto;

        public ProdutoController(
            CriarProdutoUseCase criarProduto,
            ListarProdutosUseCase listarProdutos,
            ObterProdutoPorIdUseCase obterProdutoPorId,
            ListarProdutosPorCategoriaUseCase listarProdutosPorCategoria,
            BuscarProdutoPorNomeUseCase buscarProdutoPorNome,
            AlterarNomeProdutoUseCase alterarNomeProduto,
            AlterarCategoriaProdutoUseCase alterarCategoriaProduto,
            AlterarMarcaProdutoUseCase alterarMarcaProduto,
            DesativarProdutoUseCase desativarProduto)
        {
            _criarProduto = criarProduto;
            _listarProdutos = listarProdutos;
            _obterProdutoPorId = obterProdutoPorId;
            _listarProdutosPorCategoria = listarProdutosPorCategoria;
            _buscarProdutoPorNome = buscarProdutoPorNome;
            _alterarNomeProduto = alterarNomeProduto;
            _alterarCategoriaProduto = alterarCategoriaProduto;
            _alterarMarcaProduto = alterarMarcaProduto;
            _desativarProduto = desativarProduto;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarProdutoDto dto)
        {
            var id = await _criarProduto.ExecutarAsync(dto);

            return CreatedResponse(nameof(ObterPorId), new { id }, new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var produtos = await _listarProdutos.ExecutarAsync();
            return OkResponse(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var produto = await _obterProdutoPorId.ExecutarAsync(id);

            if (produto == null)
                return NotFoundResponse();

            return OkResponse(produto);
        }

        [HttpGet("categoria/{categoriaId}")]
        public async Task<IActionResult> ListarPorCategoria(Guid categoriaId)
        {
            var produtos = await _listarProdutosPorCategoria.ExecutarAsync(categoriaId);
            return OkResponse(produtos);
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarPorNome([FromQuery] string nome)
        {
            var produtos = await _buscarProdutoPorNome.ExecutarAsync(nome);
            return OkResponse(produtos);
        }

        [HttpPut("{id}/nome")]
        public async Task<IActionResult> AlterarNome(Guid id, [FromBody] AlterarNomeProdutoDto dto)
        {
            dto.Id = id;

            await _alterarNomeProduto.ExecutarAsync(dto);

            return NoContentResponse();
        }

        [HttpPut("{id}/categoria")]
        public async Task<IActionResult> AlterarCategoria(Guid id, [FromBody] AlterarCategoriaProdutoDto dto)
        {
            dto.Id = id;

            await _alterarCategoriaProduto.ExecutarAsync(dto);

            return NoContentResponse();
        }

        [HttpPut("{id}/marca")]
        public async Task<IActionResult> AlterarMarca(Guid id, [FromBody] AlterarMarcaProdutoDto dto)
        {
            dto.Id = id;

            await _alterarMarcaProduto.ExecutarAsync(dto);

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