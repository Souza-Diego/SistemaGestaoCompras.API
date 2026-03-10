using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Marcas
{
    public class DesativarMarcaUseCase
    {
        private readonly IMarcaRepositorio _marcaRepositorio;

        public DesativarMarcaUseCase(IMarcaRepositorio marcaRepositorio)
        {
            _marcaRepositorio = marcaRepositorio;
        }

        public async Task ExecutarAsync(Guid id)
        {
            var marca = await _marcaRepositorio.BuscarPorIdAsync(id);
            if (marca == null)
                throw new Exception("Marca não encontrada.");
            marca.Desativar();
            await _marcaRepositorio.AtualizarAsync(marca);
        }
    }
}
