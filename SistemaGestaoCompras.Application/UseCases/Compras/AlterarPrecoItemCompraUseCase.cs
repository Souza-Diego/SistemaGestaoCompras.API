using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.Application.UseCases.Compras;
public class AlterarPrecoItemCompraUseCase
{
    private readonly ICompraRepositorio _repositorio;

    public AlterarPrecoItemCompraUseCase(ICompraRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task ExecutarAsync(AlterarPrecoItemCompraDto dto)
    {
        var compra = await _repositorio.BuscarPorIdAsync(dto.IdCompra);

        if (compra == null)
            throw new Exception("Compra não encontrada");

        var item = compra.Itens.FirstOrDefault(i => i.Id == dto.IdItem);

        if (item == null)
            throw new Exception("Item não encontrado");

        item.AlterarPreco(new Dinheiro(dto.PrecoUnitario));

        await _repositorio.AtualizarAsync(compra);
    }
}
