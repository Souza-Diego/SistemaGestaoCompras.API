using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Application.DTOs.Marcas;

namespace SistemaGestaoCompras.Application.UseCases.Marcas
{
    public class AlterarNomeMarcaUseCase
    {
        private readonly IMarcaRepositorio _marcaRepositorio;

        public AlterarNomeMarcaUseCase(IMarcaRepositorio marcaRepositorio)
        {
            _marcaRepositorio = marcaRepositorio;
        }

        public async Task ExecutarAsync(AlterarNomeMarcaDto dto)
        {
            var marca = await _marcaRepositorio.BuscarPorIdAsync(dto.Id);
            if (marca == null)
                throw new Exception("Marca não encontrada.");
            marca.AlterarNome(dto.Nome);
            await _marcaRepositorio.AtualizarAsync(marca);
        }
    }
}
