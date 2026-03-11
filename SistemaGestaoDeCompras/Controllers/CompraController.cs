using Microsoft.AspNetCore.Mvc;
using SistemaGestaoCompras.API.Controllers;
using SistemaGestaoCompras.Application.DTOs.Compras;
using SistemaGestaoCompras.Application.UseCases.Compras;

[Route("api/[controller]")]
public class CompraController : BaseController
{
    private readonly CriarCompraUseCase _criar;
    private readonly AdicionarItemCompraUseCase _adicionarItem;
    private readonly RemoverItemCompraUseCase _removerItem;
    private readonly AlterarQuantidadeItemCompraUseCase _alterarQuantidadeItem;
    private readonly AlterarPrecoItemCompraUseCase _alterarPrecoItem;
    private readonly FinalizarCompraUseCase _finalizar;
    private readonly RemoverCompraDosRelatoriosUseCase _removerRelatorio;
    private readonly ObterCompraPorIdUseCase _obter;
    private readonly ListarComprasDoUsuarioUseCase _listarUsuario;
    private readonly ListarComprasPorPeriodoUseCase _listarPeriodo;
    private readonly ObterTotalGastoPorPeriodoUseCase _totalPeriodo;
    private readonly ObterProdutosMaisCompradosUseCase _produtosMaisComprados;
    private readonly ObterMercadosMaisUsadosUseCase _mercadosMaisUsados;

    public CompraController(
        CriarCompraUseCase criar,
        AdicionarItemCompraUseCase adicionarItem,
        RemoverItemCompraUseCase removerItem,
        AlterarQuantidadeItemCompraUseCase alterarQuantidadeItem,
        AlterarPrecoItemCompraUseCase alterarPrecoItem,
        FinalizarCompraUseCase finalizar,
        RemoverCompraDosRelatoriosUseCase removerRelatorio,
        ObterCompraPorIdUseCase obter,
        ListarComprasDoUsuarioUseCase listarUsuario,
        ListarComprasPorPeriodoUseCase listarPeriodo,
        ObterTotalGastoPorPeriodoUseCase totalPeriodo,
        ObterProdutosMaisCompradosUseCase produtosMaisComprados,
        ObterMercadosMaisUsadosUseCase mercadosMaisUsados)
    {
        _criar = criar;
        _adicionarItem = adicionarItem;
        _removerItem = removerItem;
        _alterarQuantidadeItem = alterarQuantidadeItem;
        _alterarPrecoItem = alterarPrecoItem;
        _finalizar = finalizar;
        _removerRelatorio = removerRelatorio;
        _obter = obter;
        _listarUsuario = listarUsuario;
        _listarPeriodo = listarPeriodo;
        _totalPeriodo = totalPeriodo;
        _produtosMaisComprados = produtosMaisComprados;
        _mercadosMaisUsados = mercadosMaisUsados;
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarCompraDto dto)
    {
        var id = await _criar.ExecutarAsync(dto);
        return OkResponse(new { id });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Obter(Guid id)
    {
        var compra = await _obter.ExecutarAsync(id);

        if (compra == null)
            return NotFoundResponse();

        return OkResponse(compra);
    }

    [HttpGet("usuario/{usuarioId}")]
    public async Task<IActionResult> ListarPorUsuario(Guid usuarioId)
    {
        var compras = await _listarUsuario.ExecutarAsync(usuarioId);
        return OkResponse(compras);
    }

    [HttpPost("periodo")]
    public async Task<IActionResult> ListarPorPeriodo([FromBody] ListarComprasPeriodoDto dto)
    {
        var compras = await _listarPeriodo.ExecutarAsync(dto);
        return OkResponse(compras);
    }

    [HttpPost("{id}/finalizar")]
    public async Task<IActionResult> Finalizar(Guid id)
    {
        await _finalizar.ExecutarAsync(id);
        return NoContentResponse();
    }

    [HttpDelete("{id}/relatorio")]
    public async Task<IActionResult> RemoverDosRelatorios(Guid id)
    {
        await _removerRelatorio.ExecutarAsync(id);
        return NoContentResponse();
    }

    [HttpPost("{id}/itens")]
    public async Task<IActionResult> AdicionarItem(Guid id, [FromBody] AdicionarItemCompraDto dto)
    {
        dto.IdCompra = id;

        await _adicionarItem.ExecutarAsync(dto);

        return NoContentResponse();
    }

    [HttpDelete("{id}/itens/{itemId}")]
    public async Task<IActionResult> RemoverItem(Guid id, Guid itemId)
    {
        var dto = new RemoverItemCompraDto
        {
            IdCompra = id,
            IdItem = itemId
        };

        await _removerItem.ExecutarAsync(dto);

        return NoContentResponse();
    }

    [HttpPut("{id}/itens/{itemId}/quantidade")]
    public async Task<IActionResult> AlterarQuantidadeItem(
        Guid id,
        Guid itemId,
        [FromBody] AlterarQuantidadeItemCompraDto dto)
    {
        dto.IdCompra = id;
        dto.IdItem = itemId;

        await _alterarQuantidadeItem.ExecutarAsync(dto);

        return NoContentResponse();
    }

    [HttpPut("{id}/itens/{itemId}/preco")]
    public async Task<IActionResult> AlterarPrecoItem(
        Guid id,
        Guid itemId,
        [FromBody] AlterarPrecoItemCompraDto dto)
    {
        dto.IdCompra = id;
        dto.IdItem = itemId;

        await _alterarPrecoItem.ExecutarAsync(dto);

        return NoContentResponse();
    }

    [HttpPost("total-periodo")]
    public async Task<IActionResult> TotalGastoPeriodo([FromBody] TotalGastoPeriodoDto dto)
    {
        var total = await _totalPeriodo.ExecutarAsync(dto);
        return OkResponse(new { total });
    }

    [HttpGet("usuario/{usuarioId}/produtos-mais-comprados")]
    public async Task<IActionResult> ProdutosMaisComprados(Guid usuarioId)
    {
        var produtos = await _produtosMaisComprados.ExecutarAsync(usuarioId);
        return OkResponse(produtos);
    }

    [HttpGet("usuario/{usuarioId}/mercados-mais-usados")]
    public async Task<IActionResult> MercadosMaisUsados(Guid usuarioId)
    {
        var mercados = await _mercadosMaisUsados.ExecutarAsync(usuarioId);
        return OkResponse(mercados);
    }
}