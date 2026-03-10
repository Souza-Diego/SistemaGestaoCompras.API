using SistemaGestaoCompras.Application.DTOs.Categorias;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;

namespace SistemaGestaoCompras.Application.UseCases.Categorias
{
    public class BuscarCategoriaPorIdUseCase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public BuscarCategoriaPorIdUseCase(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<CategoriaDto?> ExecutarAsync(Guid id)
        {
            var categoria = await _categoriaRepositorio.BuscarPorIdAsync(id);

            if(categoria == null)
                return null;

            return new CategoriaDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Ativo = categoria.Ativo
            };
        }
    }
}
