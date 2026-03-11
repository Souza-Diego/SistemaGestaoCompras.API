using Microsoft.AspNetCore.Mvc;
using SistemaGestaoCompras.API.Controllers;
using SistemaGestaoCompras.Application.DTOs.ListasPadrao;
using SistemaGestaoCompras.Application.UseCases.ListasPadrao;

[Route("api/[controller]")]
public class ListaPadraoController : BaseController
{
    private readonly CriarListaPadraoUseCase _criar;
    private readonly ListarListasPadraoUsuarioUseCase _listar;
    private readonly ObterListaPadraoPorIdUseCase _obter;
    private readonly AlterarNomeListaPadraoUseCase _alterarNome;
    private readonly AdicionarItemListaPadraoUseCase _adicionarItem;
    private readonly RemoverItemListaPadraoUseCase _removerItem;
    private readonly AlterarQuantidadeItemListaPadraoUseCase _alterarQuantidade;
    private readonly AlterarUnidadeItemListaPadraoUseCase _alterarUnidade;
    private readonly DesativarListaPadraoUseCase _desativar;

    public ListaPadraoController(
        CriarListaPadraoUseCase criar,
        ListarListasPadraoUsuarioUseCase listar,
        ObterListaPadraoPorIdUseCase obter,
        AlterarNomeListaPadraoUseCase alterarNome,
        AdicionarItemListaPadraoUseCase adicionarItem,
        RemoverItemListaPadraoUseCase removerItem,
        AlterarQuantidadeItemListaPadraoUseCase alterarQuantidade,
        AlterarUnidadeItemListaPadraoUseCase alterarUnidade,
        DesativarListaPadraoUseCase desativar)
    {
        _criar = criar;
        _listar = listar;
        _obter = obter;
        _alterarNome = alterarNome;
        _adicionarItem = adicionarItem;
        _removerItem = removerItem;
        _alterarQuantidade = alterarQuantidade;
        _alterarUnidade = alterarUnidade;
        _desativar = desativar;
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarListaPadraoDto dto)
    {
        var id = await _criar.ExecutarAsync(dto);
        return OkResponse(id);
    }

    [HttpGet("usuario/{usuarioId}")]
    public async Task<IActionResult> ListarPorUsuario(Guid usuarioId)
    {
        var listas = await _listar.ExecutarAsync(usuarioId);
        return OkResponse(listas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Obter(Guid id)
    {
        var lista = await _obter.ExecutarAsync(id);

        if (lista == null)
            return NotFoundResponse();

        return OkResponse(lista);
    }

    [HttpPut("{id}/nome")]
    public async Task<IActionResult> AlterarNome(Guid id, AlterarNomeListaPadraoDto dto)
    {
        dto.Id = id;

        await _alterarNome.ExecutarAsync(dto);

        return NoContentResponse();
    }

    [HttpPost("item")]
    public async Task<IActionResult> AdicionarItem(AdicionarItemListaPadraoDto dto)
    {
        await _adicionarItem.ExecutarAsync(dto);
        return NoContentResponse();
    }

    [HttpDelete("item")]
    public async Task<IActionResult> RemoverItem(RemoverItemListaPadraoDto dto)
    {
        await _removerItem.ExecutarAsync(dto);
        return NoContentResponse();
    }

    [HttpPut("item/quantidade")]
    public async Task<IActionResult> AlterarQuantidade(AlterarQuantidadeItemListaPadraoDto dto)
    {
        await _alterarQuantidade.ExecutarAsync(dto);
        return NoContentResponse();
    }

    [HttpPut("item/unidade")]
    public async Task<IActionResult> AlterarUnidade(AlterarUnidadeItemListaPadraoDto dto)
    {
        await _alterarUnidade.ExecutarAsync(dto);
        return NoContentResponse();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Desativar(Guid id)
    {
        await _desativar.ExecutarAsync(id);
        return NoContentResponse();
    }
}