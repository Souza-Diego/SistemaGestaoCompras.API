using SistemaGestaoCompras.Application.DTOs.Compras;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Compras;

public class RemoverItemCompraUseCase
{
    private readonly ICompraRepositorio _repositorio;

    public RemoverItemCompraUseCase(ICompraRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task ExecutarAsync(RemoverItemCompraDto dto)
    {
        var compra = await _repositorio.BuscarPorIdAsync(dto.IdCompra);

        if (compra == null)
            throw new Exception("Compra não encontrada");

        compra.RemoverItem(dto.IdItem);

        await _repositorio.AtualizarAsync(compra);
    }
}