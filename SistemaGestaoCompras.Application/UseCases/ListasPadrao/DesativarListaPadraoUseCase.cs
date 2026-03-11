using SistemaGestaoCompras.Domain.Interfaces.Repositories;

public class DesativarListaPadraoUseCase
{
    private readonly IListaDeComprasPadraoRepositorio _repositorio;

    public DesativarListaPadraoUseCase(IListaDeComprasPadraoRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task ExecutarAsync(Guid id)
    {
        var lista = await _repositorio.BuscarPorIdAsync(id);

        if (lista == null)
            throw new Exception("Lista padrão não encontrada");

        lista.Desativar();

        await _repositorio.AtualizarAsync(lista);
    }
}