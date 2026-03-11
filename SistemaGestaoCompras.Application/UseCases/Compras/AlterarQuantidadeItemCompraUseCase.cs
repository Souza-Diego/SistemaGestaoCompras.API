using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Compras;
public class AlterarQuantidadeItemCompraUseCase
{
    private readonly ICompraRepositorio _repositorio;

    public AlterarQuantidadeItemCompraUseCase(ICompraRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task ExecutarAsync(AlterarQuantidadeItemCompraDto dto)
    {
        var compra = await _repositorio.BuscarPorIdAsync(dto.IdCompra);

        if (compra == null)
            throw new Exception("Compra não encontrada");

        var item = compra.Itens.FirstOrDefault(i => i.Id == dto.IdItem);

        if (item == null)
            throw new Exception("Item não encontrado");

        item.AlterarQuantidade(dto.Quantidade);

        await _repositorio.AtualizarAsync(compra);
    }
}