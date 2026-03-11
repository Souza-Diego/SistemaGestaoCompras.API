using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Compras;

public class ObterProdutosMaisCompradosUseCase
{
    private readonly ICompraRepositorio _repositorio;

    public ObterProdutosMaisCompradosUseCase(ICompraRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<IEnumerable<object>> ExecutarAsync(Guid usuarioId)
    {
        var compras = await _repositorio.ObterPorUsuarioAsync(usuarioId);

        return compras
            .SelectMany(c => c.Itens)
            .GroupBy(i => i.IdProduto)
            .Select(g => new
            {
                ProdutoId = g.Key,
                Nome = g.First().NomeProdutoSnapshot,
                QuantidadeTotal = g.Sum(i => i.Quantidade)
            })
            .OrderByDescending(p => p.QuantidadeTotal)
            .Take(10);
    }
}