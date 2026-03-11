using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Compras;
public class FinalizarCompraUseCase
{
    private readonly ICompraRepositorio _repositorio;

    public FinalizarCompraUseCase(ICompraRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task ExecutarAsync(Guid idCompra)
    {
        var compra = await _repositorio.BuscarPorIdAsync(idCompra);

        if (compra == null)
            throw new Exception("Compra não encontrada");

        compra.Finalizar();

        await _repositorio.AtualizarAsync(compra);
    }
}