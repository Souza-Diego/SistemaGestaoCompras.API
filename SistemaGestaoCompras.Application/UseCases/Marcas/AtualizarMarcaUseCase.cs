using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Application.DTOs.Marcas;

namespace SistemaGestaoCompras.Application.UseCases.Marcas
{
    public class AtualizarMarcaUseCase
    {
        private readonly IMarcaRepositorio _marcaRepositorio;

        public AtualizarMarcaUseCase(IMarcaRepositorio marcaRepositorio)
        {
            _marcaRepositorio = marcaRepositorio;
        }

        public async Task ExecutarAsync(AtualizarMarcaDto dto)
        {
            var marca = await _marcaRepositorio.BuscarPorIdAsync(dto.Id);
            if (marca == null)
                throw new Exception("Marca não encontrada.");
            marca.AlterarNome(dto.Nome);
            await _marcaRepositorio.AtualizarAsync(marca);
        }
    }
}
