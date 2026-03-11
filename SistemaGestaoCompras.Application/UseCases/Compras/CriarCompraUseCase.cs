using SistemaGestaoCompras.Application.DTOs.Compras;
using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Compras;

public class CriarCompraUseCase
{
    private readonly ICompraRepositorio _repositorio;

    public CriarCompraUseCase(ICompraRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<Guid> ExecutarAsync(CriarCompraDto dto)
    {
        var compra = new Compra(
            dto.IdUsuario,
            dto.IdMercado,
            dto.DataCompra
        );

        await _repositorio.AdicionarAsync(compra);

        return compra.Id;
    }
}