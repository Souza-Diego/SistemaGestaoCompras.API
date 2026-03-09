using SistemaGestaoCompras.Domain.Entities;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Application.DTOs.Marcas;

namespace SistemaGestaoCompras.Application.UseCases.Marcas
{
    public class CriarMarcaUseCase
    {
        private readonly IMarcaRepositorio _marcaRepositorio;

        public CriarMarcaUseCase(IMarcaRepositorio marcaRepositorio)
        {
            _marcaRepositorio = marcaRepositorio;
        }

        public async Task<Guid> ExecutarAsync(CriarMarcaDto dto)
        {
            var marca = new Marca(dto.Nome);
            await _marcaRepositorio.AdicionarAsync(marca);
            return marca.Id;
        }
    }
}
