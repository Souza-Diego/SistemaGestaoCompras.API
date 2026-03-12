using Microsoft.AspNetCore.Mvc;
using SistemaGestaoCompras.Application.DTOs.RegistroDePrecos;
using SistemaGestaoCompras.Application.UseCases.RegistroDePrecos;


namespace SistemaGestaoCompras.API.Controllers
{
    [Route("api/[controller]")]
    public class RegistroDePrecoController : BaseController
    {
        private readonly RegistrarPrecoProdutoUseCase _registrarPreco;
        private readonly CorrigirPrecoRegistradoUseCase _corrigirPreco;
        private readonly ListarPrecosProdutoUseCase _listarPrecosProduto;
        private readonly ListarPrecosPorMercadoUseCase _listarPrecosMercado;
        private readonly ObterHistoricoPrecoProdutoUseCase _historicoPreco;
        private readonly ObterMelhorPrecoProdutoUseCase _melhorPreco;
        private readonly CompararPrecosProdutoUseCase _compararPrecosProduto;

        public RegistroDePrecoController(
            RegistrarPrecoProdutoUseCase registrarPreco,
            CorrigirPrecoRegistradoUseCase corrigirPreco,
            ListarPrecosProdutoUseCase listarPrecosProduto,
            ListarPrecosPorMercadoUseCase listarPrecosMercado,
            ObterHistoricoPrecoProdutoUseCase historicoPreco,
            ObterMelhorPrecoProdutoUseCase melhorPreco,
            CompararPrecosProdutoUseCase compararPrecos)
        {
            _registrarPreco = registrarPreco;
            _corrigirPreco = corrigirPreco;
            _listarPrecosProduto = listarPrecosProduto;
            _listarPrecosMercado = listarPrecosMercado;
            _historicoPreco = historicoPreco;
            _melhorPreco = melhorPreco;
            _compararPrecosProduto = compararPrecos;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarPreco([FromBody] RegistrarPrecoProdutoDto dto)
        {
            var id = await _registrarPreco.ExecutarAsync(dto);
            return CreatedResponse(nameof(ObterHistorico), new { id }, id);
        }

        [HttpPut("corrigir")]
        public async Task<IActionResult> CorrigirPreco([FromBody] CorrigirPrecoRegistradoDto dto)
        {
            await _corrigirPreco.ExecutarAsync(dto);
            return NoContentResponse();
        }

        [HttpGet("produto/{produtoId}")]
        public async Task<IActionResult> ListarPrecosProduto(Guid produtoId)
        {
            var resultado = await _listarPrecosProduto.ExecutarAsync(produtoId);
            return OkResponse(resultado);
        }

        [HttpGet("mercado/{mercadoId}")]
        public async Task<IActionResult> ListarPrecosMercado(Guid idMercado)
        {
            var dto = new ListarPrecosPorMercadoDto
            {
                IdMercado = idMercado
            };

            var resultado = await _listarPrecosMercado.ExecutarAsync(dto);

            return OkResponse(resultado);
        }

        [HttpGet("historico/{produtoId}")]
        public async Task<IActionResult> ObterHistorico(Guid produtoId)
        {
            var resultado = await _historicoPreco.ExecutarAsync(produtoId);
            return OkResponse(resultado);
        }

        [HttpGet("melhor-preco/{produtoId}")]
        public async Task<IActionResult> MelhorPreco(Guid produtoId)
        {
            var resultado = await _melhorPreco.ExecutarAsync(produtoId);

            if (resultado == null)
                return NotFoundResponse();

            return OkResponse(resultado);
        }

        [HttpGet("produto/{produtoId}/comparar")]
        public async Task<IActionResult> CompararPrecosProduto(Guid produtoId)
        {
            var resultado = await _compararPrecosProduto.ExecutarAsync(produtoId);

            return OkResponse(resultado);
        }
    }
}