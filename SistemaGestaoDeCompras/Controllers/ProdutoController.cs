using Microsoft.AspNetCore.Mvc;
using SistemaGestaoCompras.Application.UseCases.Produtos;
using SistemaGestaoCompras.Application.DTOs.Produtos;

namespace SistemaGestaoCompras.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly CriarProdutoUseCase _criarProduto;
        private readonly AtualizarProdutoUseCase _atualizarProduto;
        private readonly DesativarProdutoUseCase _desativarProduto;
        private readonly ListarProdutosUseCase _listarProdutos;

        public ProdutoController(
            CriarProdutoUseCase criarProduto,
            AtualizarProdutoUseCase atualizarProduto,
            DesativarProdutoUseCase desativarProduto,
            ListarProdutosUseCase listarProdutos)
        {
            _criarProduto = criarProduto;
            _atualizarProduto = atualizarProduto;
            _desativarProduto = desativarProduto;
            _listarProdutos = listarProdutos;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarProdutoDto dto)
        {
            var id = await _criarProduto.ExecutarAsync(dto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarProdutoDto dto)
        {
            dto.Id = id;
            await _atualizarProduto.ExecutarAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Desativar(Guid id)
        {
            await _desativarProduto.ExecutarAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var produtos = await _listarProdutos.ExecutarAsync();
            return Ok(produtos);
        }
    }
}
