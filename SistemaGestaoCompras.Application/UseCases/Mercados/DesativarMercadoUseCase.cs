using SistemaGestaoCompras.Domain.Interfaces.Repositories;


namespace SistemaGestaoCompras.Application.UseCases.Mercados
{
    public class DesativarMercadoUseCase
    {
        private readonly IMercadoRepositorio _mercadoRepositorio;

        public DesativarMercadoUseCase(IMercadoRepositorio mercadoRepositorio)
        {
            _mercadoRepositorio = mercadoRepositorio;
        }

        public async Task ExecutarAsync(Guid id)
        {
            var mercado = await _mercadoRepositorio.BuscarPorIdAsync(id);
            if (mercado == null)
                throw new Exception("Mercado não encontrado.");
            mercado.Desativar();
            await _mercadoRepositorio.AtualizarAsync(mercado);
        }
    }
}
