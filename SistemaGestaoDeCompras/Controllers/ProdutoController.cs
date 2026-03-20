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
        private readonly AlterarQuantidadeProdutoUseCase _alterarQuantidadeProduto;
        private readonly DesativarProdutoUseCase _desativarProduto;
        private readonly ReativarProdutoUseCase _reativarProduto;
        private readonly ListarProdutosDoUsuarioUseCase _listarProdutosDoUsuario;
        private readonly AlterarUnidadeProdutoUseCase _alterarUnidadeProduto;

        public ProdutoController(
            CriarProdutoUseCase criarProduto,
            ListarProdutosUseCase listarProdutos,
            ObterProdutoPorIdUseCase obterProdutoPorId,
            ListarProdutosPorCategoriaUseCase listarProdutosPorCategoria,
            BuscarProdutoPorNomeUseCase buscarProdutoPorNome,
            AlterarNomeProdutoUseCase alterarNomeProduto,
            AlterarCategoriaProdutoUseCase alterarCategoriaProduto,
            AlterarMarcaProdutoUseCase alterarMarcaProduto,
            AlterarQuantidadeProdutoUseCase alterarQuantidadeProduto,
            DesativarProdutoUseCase desativarProduto,
            ReativarProdutoUseCase reativarProduto,
            ListarProdutosDoUsuarioUseCase listarProdutosDoUsuario,
            AlterarUnidadeProdutoUseCase alterarUnidadeProduto)
        {
            _criarProduto = criarProduto;
            _listarProdutos = listarProdutos;
            _obterProdutoPorId = obterProdutoPorId;
            _listarProdutosPorCategoria = listarProdutosPorCategoria;
            _buscarProdutoPorNome = buscarProdutoPorNome;
            _alterarNomeProduto = alterarNomeProduto;
            _alterarCategoriaProduto = alterarCategoriaProduto;
            _alterarMarcaProduto = alterarMarcaProduto;
            _alterarQuantidadeProduto = alterarQuantidadeProduto;
            _desativarProduto = desativarProduto;
            _reativarProduto = reativarProduto;
            _listarProdutosDoUsuario = listarProdutosDoUsuario;
            _alterarUnidadeProduto = alterarUnidadeProduto;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarProdutoDto dto)
        {
            var id = await _criarProduto.ExecutarAsync(dto);
            return CreatedResponse(nameof(ObterPorId), new { id }, new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Listar([FromQuery] Guid usuarioId)
        {
            var produtos = await _listarProdutos.ExecutarAsync(usuarioId);
            return OkResponse(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id, [FromQuery] Guid usuarioId)
        {
            var produto = await _obterProdutoPorId.ExecutarAsync(id, usuarioId);
            return OkResponse(produto);
        }

        [HttpGet("categoria/{categoriaId}")]
        public async Task<IActionResult> ListarPorCategoria(Guid categoriaId, [FromQuery] Guid usuarioId)
        {
            var produtos = await _listarProdutosPorCategoria.ExecutarAsync(categoriaId, usuarioId);
            return OkResponse(produtos);
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarPorNome([FromQuery] string nome)
        {
            var produtos = await _buscarProdutoPorNome.ExecutarAsync(nome);
            return OkResponse(produtos);
        }

        [HttpGet("meus-produtos")]
        public async Task<IActionResult> MeusProdutos([FromQuery] Guid usuarioId)
        {
            var produtos = await _listarProdutosDoUsuario.ExecutarAsync(usuarioId);
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
        
        [HttpPut("{id}/quantidade")]
        public async Task<IActionResult> AlterarQuantidade(Guid id, [FromBody] AlterarQuantidadeProdutoDto dto)
        {
            dto.Id = id;
            await _alterarQuantidadeProduto.ExecutarAsync(dto);
            return NoContentResponse();
        }

        [HttpPut("{id}/unidade")]
        public async Task<IActionResult> AlterarUnidade(Guid id, [FromBody] AlterarUnidadeProdutoDto dto)
        {
            dto.Id = id;
            await _alterarUnidadeProduto.ExecutarAsync(dto);
            return NoContentResponse();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Desativar(Guid id, [FromQuery] Guid usuarioId)
        {
            await _desativarProduto.ExecutarAsync(id, usuarioId);
            return NoContentResponse();
        }

        [HttpPut("{id}/reativar")]
        public async Task<IActionResult> Reativar(Guid id, [FromQuery] Guid usuarioId)
        {
            await _reativarProduto.ExecutarAsync(id, usuarioId);
            return NoContentResponse();
        }
    }
}