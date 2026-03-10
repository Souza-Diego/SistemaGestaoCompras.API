using SistemaGestaoCompras.Application.DTOs.Marcas;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Marcas
{
    public class BuscarMarcaPorIdUseCase
    {
        private readonly IMarcaRepositorio _marcaRepositorio;

        public BuscarMarcaPorIdUseCase(IMarcaRepositorio marcaRepositorio)
        {
            _marcaRepositorio = marcaRepositorio;
        }

        public async Task<MarcaDto?> ExecutarAsync(Guid id)
        {
            var marca = await _marcaRepositorio.BuscarPorIdAsync(id);

            if (marca == null)
                return null;

            return new MarcaDto
            {
                Id = marca.Id,
                Nome = marca.Nome,
                Ativo = marca.Ativo
            };
        }
    }
}