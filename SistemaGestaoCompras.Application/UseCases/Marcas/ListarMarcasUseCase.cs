using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using SistemaGestaoCompras.Application.DTOs.Marcas;

namespace SistemaGestaoCompras.Application.UseCases.Marcas
{
    public class ListarMarcasUseCase
    {
        private readonly IMarcaRepositorio _marcaRepositorio;

        public ListarMarcasUseCase(IMarcaRepositorio marcaRepositorio)
        {
            _marcaRepositorio = marcaRepositorio;
        }

        public async Task<IEnumerable<MarcaDto>> ExecutarAsync()
        {
            var marcas = await _marcaRepositorio.ListarAtivosAsync();
            return marcas.Select(m => new MarcaDto
            {
                Id = m.Id,
                Nome = m.Nome,
                Ativo = m.Ativo
            });
        }
    }
}
