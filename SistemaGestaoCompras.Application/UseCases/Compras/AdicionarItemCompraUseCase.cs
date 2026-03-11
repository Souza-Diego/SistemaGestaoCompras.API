using SistemaGestaoCompras.Application.DTOs.Compras;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Domain.ValueObjects;

namespace SistemaGestaoCompras.Application.UseCases.Compras;
public class AdicionarItemCompraUseCase
{
    private readonly ICompraRepositorio _repositorio;

    public AdicionarItemCompraUseCase(ICompraRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task ExecutarAsync(AdicionarItemCompraDto dto)
    {
        var compra = await _repositorio.BuscarPorIdAsync(dto.IdCompra);

        if (compra == null)
            throw new Exception("Compra não encontrada");

        compra.AdicionarItem(
            dto.IdProduto,
            dto.NomeProduto,
            dto.Quantidade,
            new Dinheiro(dto.PrecoUnitario),
            dto.Unidade
        );

        await _repositorio.AtualizarAsync(compra);
    }
}