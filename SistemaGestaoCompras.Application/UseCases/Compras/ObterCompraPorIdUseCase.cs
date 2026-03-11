using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Compras;
public class ObterCompraPorIdUseCase
{
    private readonly ICompraRepositorio _repositorio;

    public ObterCompraPorIdUseCase(ICompraRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<Compra?> ExecutarAsync(Guid id)
    {
        return await _repositorio.BuscarPorIdAsync(id);
    }
}