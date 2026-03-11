using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Compras;
public class RemoverCompraDosRelatoriosUseCase
{
    private readonly ICompraRepositorio _repositorio;

    public RemoverCompraDosRelatoriosUseCase(ICompraRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task ExecutarAsync(Guid idCompra)
    {
        var compra = await _repositorio.BuscarPorIdAsync(idCompra);

        if (compra == null)
            throw new Exception("Compra não encontrada");

        compra.RemoverDosRelatorios();

        await _repositorio.AtualizarAsync(compra);
    }
}
